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
            this.txtSSNITER = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTotalSalaryEarned = new System.Windows.Forms.TextBox();
            this.txtProvidentFundEmployer = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtProvidentFundEmployee = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnSMSSelected = new System.Windows.Forms.Button();
            this.txtGrossIncome = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalLoan = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTaxableIncome = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNetPay = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSSNIT = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtIncomeTax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalDeduction = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalAllowance = new System.Windows.Forms.TextBox();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.btnPrintAllSlips = new System.Windows.Forms.Button();
            this.btnEmailSelected = new System.Windows.Forms.Button();
            this.btnRemoveSelectedSlips = new System.Windows.Forms.Button();
            this.btnEmployeeBanks = new System.Windows.Forms.Button();
            this.btnSalaryInfo = new System.Windows.Forms.Button();
            this.btnPrintSelectedSlips = new System.Windows.Forms.Button();
            this.grid1 = new System.Windows.Forms.DataGridView();
            this.grid1StaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1StaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1MobileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1Mechanised = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1AttendanceDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewSelectedSlips = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnLoanPayments = new System.Windows.Forms.Button();
            this.btnMedicalClaim = new System.Windows.Forms.Button();
            this.btnDeductions = new System.Windows.Forms.Button();
            this.btnAllowances = new System.Windows.Forms.Button();
            this.txtNoPayrollStaff = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFileFomats = new System.Windows.Forms.ComboBox();
            this.btnEmailAll = new System.Windows.Forms.Button();
            this.btnViewPayRoll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSMS = new System.Windows.Forms.Button();
            this.btnDeletePayRoll = new System.Windows.Forms.Button();
            this.btnOpenPayRoll = new System.Windows.Forms.Button();
            this.btnPrintPayRoll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClosePayRoll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxExemptOtherDeductions = new System.Windows.Forms.CheckBox();
            this.checkBoxExemptAllowances = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboMechanised = new System.Windows.Forms.ComboBox();
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
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payRollRegisterOldFormat1 = new eMAS.Forms.Reports.PayRollRegisterOldFormat();
            this.paySlipReport1 = new eMAS.Forms.Reports.PaySlipReport();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPaymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAttendanceDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridBasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridActualBasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAllowances = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMedicalClaims = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridArrears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTotalOverTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTotalOverTimeHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGrandTotalAllowance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGrossSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSNNITEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridProvidentFundEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridProvidentFundEmployer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTotalTaxAllowance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTaxableIncome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridWithholdingTaxRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridWithholdingTaxCalculateOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridWithholdingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridWithholdingTaxFixedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridIncomeTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridNetAfterTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSusuPlusContribution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDeductions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridInitialLoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGrandTotalDeduction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridNetSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTakeHome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSSNITNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGradeLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSSNITEmployer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSSNITFirstTier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSecondTier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMobileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMechanised = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.attendanceGroupBox.Controls.Add(this.txtSSNITER);
            this.attendanceGroupBox.Controls.Add(this.label25);
            this.attendanceGroupBox.Controls.Add(this.label23);
            this.attendanceGroupBox.Controls.Add(this.txtTotalSalaryEarned);
            this.attendanceGroupBox.Controls.Add(this.txtProvidentFundEmployer);
            this.attendanceGroupBox.Controls.Add(this.label22);
            this.attendanceGroupBox.Controls.Add(this.txtProvidentFundEmployee);
            this.attendanceGroupBox.Controls.Add(this.label21);
            this.attendanceGroupBox.Controls.Add(this.btnSMSSelected);
            this.attendanceGroupBox.Controls.Add(this.txtGrossIncome);
            this.attendanceGroupBox.Controls.Add(this.label19);
            this.attendanceGroupBox.Controls.Add(this.label18);
            this.attendanceGroupBox.Controls.Add(this.txtTotalLoan);
            this.attendanceGroupBox.Controls.Add(this.label17);
            this.attendanceGroupBox.Controls.Add(this.txtTaxableIncome);
            this.attendanceGroupBox.Controls.Add(this.label16);
            this.attendanceGroupBox.Controls.Add(this.txtNetPay);
            this.attendanceGroupBox.Controls.Add(this.label15);
            this.attendanceGroupBox.Controls.Add(this.txtSSNIT);
            this.attendanceGroupBox.Controls.Add(this.label14);
            this.attendanceGroupBox.Controls.Add(this.txtIncomeTax);
            this.attendanceGroupBox.Controls.Add(this.label13);
            this.attendanceGroupBox.Controls.Add(this.txtTotalDeduction);
            this.attendanceGroupBox.Controls.Add(this.label12);
            this.attendanceGroupBox.Controls.Add(this.label11);
            this.attendanceGroupBox.Controls.Add(this.label10);
            this.attendanceGroupBox.Controls.Add(this.txtTotalAllowance);
            this.attendanceGroupBox.Controls.Add(this.txtBasicSalary);
            this.attendanceGroupBox.Controls.Add(this.btnPrintAllSlips);
            this.attendanceGroupBox.Controls.Add(this.btnEmailSelected);
            this.attendanceGroupBox.Controls.Add(this.btnRemoveSelectedSlips);
            this.attendanceGroupBox.Controls.Add(this.btnEmployeeBanks);
            this.attendanceGroupBox.Controls.Add(this.btnSalaryInfo);
            this.attendanceGroupBox.Controls.Add(this.btnPrintSelectedSlips);
            this.attendanceGroupBox.Controls.Add(this.grid1);
            this.attendanceGroupBox.Controls.Add(this.btnViewSelectedSlips);
            this.attendanceGroupBox.Controls.Add(this.grid);
            this.attendanceGroupBox.Controls.Add(this.btnLoanPayments);
            this.attendanceGroupBox.Controls.Add(this.btnMedicalClaim);
            this.attendanceGroupBox.Controls.Add(this.btnDeductions);
            this.attendanceGroupBox.Controls.Add(this.btnAllowances);
            this.attendanceGroupBox.Enabled = false;
            this.attendanceGroupBox.Location = new System.Drawing.Point(11, 156);
            this.attendanceGroupBox.Name = "attendanceGroupBox";
            this.attendanceGroupBox.Size = new System.Drawing.Size(1120, 417);
            this.attendanceGroupBox.TabIndex = 12;
            this.attendanceGroupBox.TabStop = false;
            this.attendanceGroupBox.Text = "Staff To Be Put On PayRoll";
            // 
            // txtSSNITER
            // 
            this.txtSSNITER.Enabled = false;
            this.txtSSNITER.Location = new System.Drawing.Point(745, 337);
            this.txtSSNITER.Name = "txtSSNITER";
            this.txtSSNITER.Size = new System.Drawing.Size(76, 21);
            this.txtSSNITER.TabIndex = 48;
            this.txtSSNITER.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(697, 341);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(45, 13);
            this.label25.TabIndex = 47;
            this.label25.Text = "SSF ER:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(743, 368);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 13);
            this.label23.TabIndex = 46;
            this.label23.Text = "Salary Earned:";
            // 
            // txtTotalSalaryEarned
            // 
            this.txtTotalSalaryEarned.Enabled = false;
            this.txtTotalSalaryEarned.Location = new System.Drawing.Point(823, 363);
            this.txtTotalSalaryEarned.Name = "txtTotalSalaryEarned";
            this.txtTotalSalaryEarned.Size = new System.Drawing.Size(80, 21);
            this.txtTotalSalaryEarned.TabIndex = 45;
            // 
            // txtProvidentFundEmployer
            // 
            this.txtProvidentFundEmployer.Enabled = false;
            this.txtProvidentFundEmployer.Location = new System.Drawing.Point(139, 364);
            this.txtProvidentFundEmployer.Name = "txtProvidentFundEmployer";
            this.txtProvidentFundEmployer.Size = new System.Drawing.Size(79, 21);
            this.txtProvidentFundEmployer.TabIndex = 44;
            this.txtProvidentFundEmployer.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 368);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(131, 13);
            this.label22.TabIndex = 43;
            this.label22.Text = "Provident Fund Employer:";
            // 
            // txtProvidentFundEmployee
            // 
            this.txtProvidentFundEmployee.Enabled = false;
            this.txtProvidentFundEmployee.Location = new System.Drawing.Point(864, 337);
            this.txtProvidentFundEmployee.Name = "txtProvidentFundEmployee";
            this.txtProvidentFundEmployee.Size = new System.Drawing.Size(79, 21);
            this.txtProvidentFundEmployee.TabIndex = 42;
            this.txtProvidentFundEmployee.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(824, 341);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 13);
            this.label21.TabIndex = 41;
            this.label21.Text = "PF EE:";
            // 
            // btnSMSSelected
            // 
            this.btnSMSSelected.Location = new System.Drawing.Point(527, 390);
            this.btnSMSSelected.Name = "btnSMSSelected";
            this.btnSMSSelected.Size = new System.Drawing.Size(84, 23);
            this.btnSMSSelected.TabIndex = 40;
            this.btnSMSSelected.Text = "SMS Selected";
            this.btnSMSSelected.UseVisualStyleBackColor = true;
            this.btnSMSSelected.Click += new System.EventHandler(this.btnSMSSelected_Click);
            // 
            // txtGrossIncome
            // 
            this.txtGrossIncome.Enabled = false;
            this.txtGrossIncome.Location = new System.Drawing.Point(468, 365);
            this.txtGrossIncome.Name = "txtGrossIncome";
            this.txtGrossIncome.Size = new System.Drawing.Size(100, 21);
            this.txtGrossIncome.TabIndex = 39;
            this.txtGrossIncome.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(392, 368);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "Gross Income:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(571, 368);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "Total Loan:";
            // 
            // txtTotalLoan
            // 
            this.txtTotalLoan.Enabled = false;
            this.txtTotalLoan.Location = new System.Drawing.Point(635, 365);
            this.txtTotalLoan.Name = "txtTotalLoan";
            this.txtTotalLoan.Size = new System.Drawing.Size(100, 21);
            this.txtTotalLoan.TabIndex = 36;
            this.txtTotalLoan.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(961, 367);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "Net Pay:";
            // 
            // txtTaxableIncome
            // 
            this.txtTaxableIncome.Enabled = false;
            this.txtTaxableIncome.Location = new System.Drawing.Point(1014, 337);
            this.txtTaxableIncome.Name = "txtTaxableIncome";
            this.txtTaxableIncome.Size = new System.Drawing.Size(100, 21);
            this.txtTaxableIncome.TabIndex = 34;
            this.txtTaxableIncome.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(944, 341);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Taxable Inc.:";
            // 
            // txtNetPay
            // 
            this.txtNetPay.Enabled = false;
            this.txtNetPay.Location = new System.Drawing.Point(1014, 363);
            this.txtNetPay.Name = "txtNetPay";
            this.txtNetPay.Size = new System.Drawing.Size(100, 21);
            this.txtNetPay.TabIndex = 32;
            this.txtNetPay.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(970, 341);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Net Pay:";
            // 
            // txtSSNIT
            // 
            this.txtSSNIT.Enabled = false;
            this.txtSSNIT.Location = new System.Drawing.Point(596, 337);
            this.txtSSNIT.Name = "txtSSNIT";
            this.txtSSNIT.Size = new System.Drawing.Size(100, 21);
            this.txtSSNIT.TabIndex = 30;
            this.txtSSNIT.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(548, 341);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "SSF EE:";
            // 
            // txtIncomeTax
            // 
            this.txtIncomeTax.Enabled = false;
            this.txtIncomeTax.Location = new System.Drawing.Point(289, 364);
            this.txtIncomeTax.Name = "txtIncomeTax";
            this.txtIncomeTax.Size = new System.Drawing.Size(100, 21);
            this.txtIncomeTax.TabIndex = 28;
            this.txtIncomeTax.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 369);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Income Tax:";
            // 
            // txtTotalDeduction
            // 
            this.txtTotalDeduction.Enabled = false;
            this.txtTotalDeduction.Location = new System.Drawing.Point(445, 337);
            this.txtTotalDeduction.Name = "txtTotalDeduction";
            this.txtTotalDeduction.Size = new System.Drawing.Size(100, 21);
            this.txtTotalDeduction.TabIndex = 26;
            this.txtTotalDeduction.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(356, 341);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Total Deduction:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 342);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Total Allowance:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 341);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "A. Basic Salary:";
            // 
            // txtTotalAllowance
            // 
            this.txtTotalAllowance.Enabled = false;
            this.txtTotalAllowance.Location = new System.Drawing.Point(258, 337);
            this.txtTotalAllowance.Name = "txtTotalAllowance";
            this.txtTotalAllowance.Size = new System.Drawing.Size(97, 21);
            this.txtTotalAllowance.TabIndex = 22;
            this.txtTotalAllowance.Text = "0";
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Enabled = false;
            this.txtBasicSalary.Location = new System.Drawing.Point(90, 337);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(78, 21);
            this.txtBasicSalary.TabIndex = 21;
            this.txtBasicSalary.Text = "0";
            // 
            // btnPrintAllSlips
            // 
            this.btnPrintAllSlips.Location = new System.Drawing.Point(349, 388);
            this.btnPrintAllSlips.Name = "btnPrintAllSlips";
            this.btnPrintAllSlips.Size = new System.Drawing.Size(78, 25);
            this.btnPrintAllSlips.TabIndex = 16;
            this.btnPrintAllSlips.Text = "Print All Slips";
            this.btnPrintAllSlips.UseVisualStyleBackColor = true;
            this.btnPrintAllSlips.Click += new System.EventHandler(this.btnPrintAllSlips_Click);
            // 
            // btnEmailSelected
            // 
            this.btnEmailSelected.Location = new System.Drawing.Point(428, 390);
            this.btnEmailSelected.Name = "btnEmailSelected";
            this.btnEmailSelected.Size = new System.Drawing.Size(98, 23);
            this.btnEmailSelected.TabIndex = 18;
            this.btnEmailSelected.Text = "Email Selected";
            this.btnEmailSelected.UseVisualStyleBackColor = true;
            this.btnEmailSelected.Click += new System.EventHandler(this.btnEmailSelected_Click);
            // 
            // btnRemoveSelectedSlips
            // 
            this.btnRemoveSelectedSlips.Location = new System.Drawing.Point(6, 388);
            this.btnRemoveSelectedSlips.Name = "btnRemoveSelectedSlips";
            this.btnRemoveSelectedSlips.Size = new System.Drawing.Size(124, 25);
            this.btnRemoveSelectedSlips.TabIndex = 15;
            this.btnRemoveSelectedSlips.Text = "Remove Selected Slips";
            this.btnRemoveSelectedSlips.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedSlips.Click += new System.EventHandler(this.btnRemoveSelectedSlips_Click);
            // 
            // btnEmployeeBanks
            // 
            this.btnEmployeeBanks.Location = new System.Drawing.Point(627, 387);
            this.btnEmployeeBanks.Name = "btnEmployeeBanks";
            this.btnEmployeeBanks.Size = new System.Drawing.Size(93, 25);
            this.btnEmployeeBanks.TabIndex = 14;
            this.btnEmployeeBanks.Text = "Employee Banks";
            this.btnEmployeeBanks.UseVisualStyleBackColor = true;
            this.btnEmployeeBanks.Click += new System.EventHandler(this.btnEmployeeBanks_Click);
            // 
            // btnSalaryInfo
            // 
            this.btnSalaryInfo.Location = new System.Drawing.Point(721, 387);
            this.btnSalaryInfo.Name = "btnSalaryInfo";
            this.btnSalaryInfo.Size = new System.Drawing.Size(68, 25);
            this.btnSalaryInfo.TabIndex = 13;
            this.btnSalaryInfo.Text = "Salary Info";
            this.btnSalaryInfo.UseVisualStyleBackColor = true;
            this.btnSalaryInfo.Click += new System.EventHandler(this.btnSalaryInfo_Click);
            // 
            // btnPrintSelectedSlips
            // 
            this.btnPrintSelectedSlips.Location = new System.Drawing.Point(240, 388);
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
            this.grid1StaffCode,
            this.grid1StaffNo,
            this.grid1Name,
            this.grid1Title,
            this.grid1Email,
            this.grid1MobileNumber,
            this.grid1Mechanised,
            this.grid1AttendanceDays});
            this.grid1.Location = new System.Drawing.Point(845, 142);
            this.grid1.Name = "grid1";
            this.grid1.ReadOnly = true;
            this.grid1.Size = new System.Drawing.Size(240, 150);
            this.grid1.TabIndex = 12;
            this.grid1.Visible = false;
            // 
            // grid1StaffCode
            // 
            this.grid1StaffCode.HeaderText = "StaffCode";
            this.grid1StaffCode.Name = "grid1StaffCode";
            this.grid1StaffCode.ReadOnly = true;
            this.grid1StaffCode.Visible = false;
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
            // grid1Title
            // 
            this.grid1Title.HeaderText = "Title";
            this.grid1Title.Name = "grid1Title";
            this.grid1Title.ReadOnly = true;
            // 
            // grid1Email
            // 
            this.grid1Email.HeaderText = "Email";
            this.grid1Email.Name = "grid1Email";
            this.grid1Email.ReadOnly = true;
            // 
            // grid1MobileNumber
            // 
            this.grid1MobileNumber.HeaderText = "MobileNo";
            this.grid1MobileNumber.Name = "grid1MobileNumber";
            this.grid1MobileNumber.ReadOnly = true;
            // 
            // grid1Mechanised
            // 
            this.grid1Mechanised.HeaderText = "Mechanised";
            this.grid1Mechanised.Name = "grid1Mechanised";
            this.grid1Mechanised.ReadOnly = true;
            // 
            // grid1AttendanceDays
            // 
            this.grid1AttendanceDays.HeaderText = "Attendance Days";
            this.grid1AttendanceDays.Name = "grid1AttendanceDays";
            this.grid1AttendanceDays.ReadOnly = true;
            // 
            // btnViewSelectedSlips
            // 
            this.btnViewSelectedSlips.Location = new System.Drawing.Point(131, 388);
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
            this.gridStaffCode,
            this.gridPaymentID,
            this.gridStaffNo,
            this.gridTitle,
            this.gridName,
            this.gridAttendanceDays,
            this.gridMonth,
            this.gridYear,
            this.gridBasicSalary,
            this.gridActualBasicSalary,
            this.gridAllowances,
            this.gridMedicalClaims,
            this.gridArrears,
            this.gridTotalOverTimes,
            this.gridTotalOverTimeHours,
            this.gridGrandTotalAllowance,
            this.gridGrossSalary,
            this.gridSNNITEmployee,
            this.gridProvidentFundEmployee,
            this.gridProvidentFundEmployer,
            this.gridTotalTaxAllowance,
            this.gridTaxableIncome,
            this.gridWithholdingTaxRate,
            this.gridWithholdingTaxCalculateOn,
            this.gridWithholdingAmount,
            this.gridWithholdingTaxFixedAmount,
            this.gridIncomeTax,
            this.gridNetAfterTax,
            this.gridSusuPlusContribution,
            this.gridDeductions,
            this.gridLoan,
            this.gridInitialLoan,
            this.gridGrandTotalDeduction,
            this.gridNetSalary,
            this.gridTakeHome,
            this.gridPaymentMode,
            this.gridDepartment,
            this.gridSSNITNo,
            this.gridGrade,
            this.gridGradeLevel,
            this.gridSSNITEmployer,
            this.gridSSNITFirstTier,
            this.gridSecondTier,
            this.gridEmail,
            this.gridMobileNumber,
            this.gridStatus,
            this.gridMechanised});
            this.grid.Location = new System.Drawing.Point(4, 18);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1111, 313);
            this.grid.TabIndex = 0;
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // btnLoanPayments
            // 
            this.btnLoanPayments.Location = new System.Drawing.Point(1029, 387);
            this.btnLoanPayments.Name = "btnLoanPayments";
            this.btnLoanPayments.Size = new System.Drawing.Size(88, 25);
            this.btnLoanPayments.TabIndex = 8;
            this.btnLoanPayments.Text = "Loan Payments";
            this.btnLoanPayments.UseVisualStyleBackColor = true;
            this.btnLoanPayments.Click += new System.EventHandler(this.btnLoanPayments_Click);
            // 
            // btnMedicalClaim
            // 
            this.btnMedicalClaim.Location = new System.Drawing.Point(791, 387);
            this.btnMedicalClaim.Name = "btnMedicalClaim";
            this.btnMedicalClaim.Size = new System.Drawing.Size(85, 25);
            this.btnMedicalClaim.TabIndex = 7;
            this.btnMedicalClaim.Text = "Medical Claims";
            this.btnMedicalClaim.UseVisualStyleBackColor = true;
            this.btnMedicalClaim.Click += new System.EventHandler(this.btnMedicalClaim_Click);
            // 
            // btnDeductions
            // 
            this.btnDeductions.Location = new System.Drawing.Point(953, 387);
            this.btnDeductions.Name = "btnDeductions";
            this.btnDeductions.Size = new System.Drawing.Size(73, 25);
            this.btnDeductions.TabIndex = 5;
            this.btnDeductions.Text = "Deductions";
            this.btnDeductions.UseVisualStyleBackColor = true;
            this.btnDeductions.Click += new System.EventHandler(this.btnDeductions_Click);
            // 
            // btnAllowances
            // 
            this.btnAllowances.Location = new System.Drawing.Point(878, 387);
            this.btnAllowances.Name = "btnAllowances";
            this.btnAllowances.Size = new System.Drawing.Size(73, 25);
            this.btnAllowances.TabIndex = 6;
            this.btnAllowances.Text = "Allowances";
            this.btnAllowances.UseVisualStyleBackColor = true;
            this.btnAllowances.Click += new System.EventHandler(this.btnAllowances_Click);
            // 
            // txtNoPayrollStaff
            // 
            this.txtNoPayrollStaff.Enabled = false;
            this.txtNoPayrollStaff.ForeColor = System.Drawing.SystemColors.Window;
            this.txtNoPayrollStaff.Location = new System.Drawing.Point(841, 7);
            this.txtNoPayrollStaff.Name = "txtNoPayrollStaff";
            this.txtNoPayrollStaff.Size = new System.Drawing.Size(72, 21);
            this.txtNoPayrollStaff.TabIndex = 20;
            this.txtNoPayrollStaff.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(717, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "No. Of Staff On Payroll:";
            // 
            // cmbFileFomats
            // 
            this.cmbFileFomats.FormattingEnabled = true;
            this.cmbFileFomats.Location = new System.Drawing.Point(609, 7);
            this.cmbFileFomats.Name = "cmbFileFomats";
            this.cmbFileFomats.Size = new System.Drawing.Size(103, 21);
            this.cmbFileFomats.TabIndex = 18;
            this.cmbFileFomats.DropDown += new System.EventHandler(this.cmbFileFomats_DropDown);
            // 
            // btnEmailAll
            // 
            this.btnEmailAll.Location = new System.Drawing.Point(528, 6);
            this.btnEmailAll.Name = "btnEmailAll";
            this.btnEmailAll.Size = new System.Drawing.Size(75, 23);
            this.btnEmailAll.TabIndex = 17;
            this.btnEmailAll.Text = "Email All";
            this.btnEmailAll.UseVisualStyleBackColor = true;
            this.btnEmailAll.Click += new System.EventHandler(this.btnEmailAll_Click);
            // 
            // btnViewPayRoll
            // 
            this.btnViewPayRoll.Location = new System.Drawing.Point(264, 5);
            this.btnViewPayRoll.Name = "btnViewPayRoll";
            this.btnViewPayRoll.Size = new System.Drawing.Size(85, 25);
            this.btnViewPayRoll.TabIndex = 11;
            this.btnViewPayRoll.Text = "View Pay Roll";
            this.btnViewPayRoll.UseVisualStyleBackColor = true;
            this.btnViewPayRoll.Click += new System.EventHandler(this.btnViewPayRoll_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(4, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 35);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btnSMS);
            this.panel2.Controls.Add(this.cmbFileFomats);
            this.panel2.Controls.Add(this.btnEmailAll);
            this.panel2.Controls.Add(this.btnDeletePayRoll);
            this.panel2.Controls.Add(this.btnOpenPayRoll);
            this.panel2.Controls.Add(this.btnPrintPayRoll);
            this.panel2.Controls.Add(this.btnViewPayRoll);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnClosePayRoll);
            this.panel2.Controls.Add(this.txtNoPayrollStaff);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(1, 574);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1156, 35);
            this.panel2.TabIndex = 14;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label24.Location = new System.Drawing.Point(915, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 13);
            this.label24.TabIndex = 23;
            this.label24.Text = "No. Of Hours Wk:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(1011, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 21);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "0";
            // 
            // btnSMS
            // 
            this.btnSMS.Location = new System.Drawing.Point(445, 6);
            this.btnSMS.Name = "btnSMS";
            this.btnSMS.Size = new System.Drawing.Size(75, 23);
            this.btnSMS.TabIndex = 21;
            this.btnSMS.Text = "SMS All";
            this.btnSMS.UseVisualStyleBackColor = true;
            this.btnSMS.Click += new System.EventHandler(this.btnSMS_Click);
            // 
            // btnDeletePayRoll
            // 
            this.btnDeletePayRoll.Location = new System.Drawing.Point(3, 5);
            this.btnDeletePayRoll.Name = "btnDeletePayRoll";
            this.btnDeletePayRoll.Size = new System.Drawing.Size(91, 25);
            this.btnDeletePayRoll.TabIndex = 16;
            this.btnDeletePayRoll.Text = "Delete PayRoll";
            this.btnDeletePayRoll.UseVisualStyleBackColor = true;
            this.btnDeletePayRoll.Click += new System.EventHandler(this.btnDeletePayRoll_Click);
            // 
            // btnOpenPayRoll
            // 
            this.btnOpenPayRoll.Location = new System.Drawing.Point(96, 5);
            this.btnOpenPayRoll.Name = "btnOpenPayRoll";
            this.btnOpenPayRoll.Size = new System.Drawing.Size(83, 25);
            this.btnOpenPayRoll.TabIndex = 15;
            this.btnOpenPayRoll.Text = "Open PayRoll";
            this.btnOpenPayRoll.UseVisualStyleBackColor = true;
            this.btnOpenPayRoll.Visible = false;
            this.btnOpenPayRoll.Click += new System.EventHandler(this.btnOpenPayRoll_Click);
            // 
            // btnPrintPayRoll
            // 
            this.btnPrintPayRoll.Location = new System.Drawing.Point(350, 5);
            this.btnPrintPayRoll.Name = "btnPrintPayRoll";
            this.btnPrintPayRoll.Size = new System.Drawing.Size(89, 25);
            this.btnPrintPayRoll.TabIndex = 14;
            this.btnPrintPayRoll.Text = "Print Pay Roll";
            this.btnPrintPayRoll.UseVisualStyleBackColor = true;
            this.btnPrintPayRoll.Visible = false;
            this.btnPrintPayRoll.Click += new System.EventHandler(this.btnPrintPayRoll_Click);
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
            // btnClosePayRoll
            // 
            this.btnClosePayRoll.Location = new System.Drawing.Point(180, 5);
            this.btnClosePayRoll.Name = "btnClosePayRoll";
            this.btnClosePayRoll.Size = new System.Drawing.Size(83, 25);
            this.btnClosePayRoll.TabIndex = 3;
            this.btnClosePayRoll.Text = "Close PayRoll";
            this.btnClosePayRoll.UseVisualStyleBackColor = true;
            this.btnClosePayRoll.Click += new System.EventHandler(this.btnClosePayRoll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cboMechanised);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxExemptOtherDeductions);
            this.groupBox3.Controls.Add(this.checkBoxExemptAllowances);
            this.groupBox3.Location = new System.Drawing.Point(550, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 86);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Exemptions";
            // 
            // checkBoxExemptOtherDeductions
            // 
            this.checkBoxExemptOtherDeductions.AutoSize = true;
            this.checkBoxExemptOtherDeductions.Location = new System.Drawing.Point(12, 52);
            this.checkBoxExemptOtherDeductions.Name = "checkBoxExemptOtherDeductions";
            this.checkBoxExemptOtherDeductions.Size = new System.Drawing.Size(110, 17);
            this.checkBoxExemptOtherDeductions.TabIndex = 1;
            this.checkBoxExemptOtherDeductions.Text = "Other Deductions";
            this.checkBoxExemptOtherDeductions.UseVisualStyleBackColor = true;
            // 
            // checkBoxExemptAllowances
            // 
            this.checkBoxExemptAllowances.AutoSize = true;
            this.checkBoxExemptAllowances.Location = new System.Drawing.Point(12, 24);
            this.checkBoxExemptAllowances.Name = "checkBoxExemptAllowances";
            this.checkBoxExemptAllowances.Size = new System.Drawing.Size(79, 17);
            this.checkBoxExemptAllowances.TabIndex = 0;
            this.checkBoxExemptAllowances.Text = "Allowances";
            this.checkBoxExemptAllowances.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "Mechanised:";
            // 
            // cboMechanised
            // 
            this.cboMechanised.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMechanised.FormattingEnabled = true;
            this.cboMechanised.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cboMechanised.Location = new System.Drawing.Point(98, 41);
            this.cboMechanised.Name = "cboMechanised";
            this.cboMechanised.Size = new System.Drawing.Size(121, 21);
            this.cboMechanised.TabIndex = 28;
            this.cboMechanised.SelectedIndexChanged += new System.EventHandler(this.cboMechanised_SelectedIndexChanged);
            // 
            // payRollButton
            // 
            this.payRollButton.Location = new System.Drawing.Point(728, 29);
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
            this.nameTextBox.Location = new System.Drawing.Point(98, 63);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(223, 21);
            this.nameTextBox.TabIndex = 18;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // staffIDTextBox
            // 
            this.staffIDTextBox.BackColor = System.Drawing.Color.White;
            this.staffIDTextBox.Location = new System.Drawing.Point(98, 86);
            this.staffIDTextBox.Name = "staffIDTextBox";
            this.staffIDTextBox.Size = new System.Drawing.Size(114, 21);
            this.staffIDTextBox.TabIndex = 17;
            this.staffIDTextBox.TextChanged += new System.EventHandler(this.staffIDTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 90);
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
            this.periodGroupBox.Location = new System.Drawing.Point(330, 14);
            this.periodGroupBox.Name = "periodGroupBox";
            this.periodGroupBox.Size = new System.Drawing.Size(197, 86);
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
            this.periodComboBox.DropDown += new System.EventHandler(this.periodComboBox_DropDown);
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(66, 48);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(121, 21);
            this.yearComboBox.TabIndex = 1;
            this.yearComboBox.DropDown += new System.EventHandler(this.yearComboBox_DropDown);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.BackColor = System.Drawing.Color.Transparent;
            this.yearLabel.Location = new System.Drawing.Point(30, 52);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(33, 13);
            this.yearLabel.TabIndex = 0;
            this.yearLabel.Text = "Year:";
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.BackColor = System.Drawing.Color.Transparent;
            this.periodLabel.Location = new System.Drawing.Point(28, 26);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(35, 13);
            this.periodLabel.TabIndex = 0;
            this.periodLabel.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Department:";
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(98, 17);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(223, 21);
            this.cmbDepartments.TabIndex = 14;
            this.cmbDepartments.SelectedIndexChanged += new System.EventHandler(this.cmbDepartments_SelectedIndexChanged);
            this.cmbDepartments.DropDown += new System.EventHandler(this.cmbDepartments_DropDown);
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
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn7.HeaderText = "Start Date";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 250;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Attendance";
            this.dataGridViewTextBoxColumn8.HeaderText = "End Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn9.HeaderText = "SSNIT (Employee)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 250;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Attendance";
            this.dataGridViewTextBoxColumn10.HeaderText = "SSNIT (Employer";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 120;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Attendance";
            this.dataGridViewTextBoxColumn11.HeaderText = "Income Tax";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "StaffID";
            this.dataGridViewTextBoxColumn12.HeaderText = "Net After Tax";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 50;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn13.HeaderText = "Net Salary";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 250;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Attendance";
            this.dataGridViewTextBoxColumn14.HeaderText = "Medical Claims";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 120;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Attendance";
            this.dataGridViewTextBoxColumn15.HeaderText = "Take Home";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 120;
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
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.HeaderText = "SSNIT (Employer)";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.HeaderText = "Status";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.HeaderText = "SSNIT No";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.HeaderText = "Grade Level";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.HeaderText = "SSNIT (Employer)";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.HeaderText = "Status";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.HeaderText = "Status";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.HeaderText = "Status";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.HeaderText = "Grade Level";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.HeaderText = "SSNIT (Employer)";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.HeaderText = "Status";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.HeaderText = "Grade Level";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.HeaderText = "SSNIT (Employer)";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.HeaderText = "Email";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.HeaderText = "MobileNo";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.HeaderText = "Status";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.HeaderText = "MobileNo";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.HeaderText = "Status";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.HeaderText = "Status";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.HeaderText = "Mechanised";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.HeaderText = "Mechanised";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.HeaderText = "Status";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.HeaderText = "Mechanised";
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.HeaderText = "Mechanised";
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.HeaderText = "Mechanised";
            this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            this.dataGridViewTextBoxColumn54.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn55
            // 
            this.dataGridViewTextBoxColumn55.HeaderText = "Status";
            this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            this.dataGridViewTextBoxColumn55.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn56
            // 
            this.dataGridViewTextBoxColumn56.HeaderText = "Mechanised";
            this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
            this.dataGridViewTextBoxColumn56.ReadOnly = true;
            // 
            // payRollRegisterOldFormat1
            // 
            this.payRollRegisterOldFormat1.FileName = "rassdk://C:\\Users\\User\\AppData\\Local\\Temp\\temp_cdc3a52f-95ef-4024-8a1e-ee790c954a" +
                "2d.rpt";
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
            // gridTitle
            // 
            this.gridTitle.HeaderText = "Title";
            this.gridTitle.Name = "gridTitle";
            this.gridTitle.ReadOnly = true;
            this.gridTitle.Width = 50;
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
            this.gridAttendanceDays.HeaderText = "Attendance";
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
            this.gridBasicSalary.HeaderText = "Salary Earned";
            this.gridBasicSalary.Name = "gridBasicSalary";
            this.gridBasicSalary.ReadOnly = true;
            // 
            // gridActualBasicSalary
            // 
            this.gridActualBasicSalary.HeaderText = "Act. Basic Salary";
            this.gridActualBasicSalary.Name = "gridActualBasicSalary";
            this.gridActualBasicSalary.ReadOnly = true;
            // 
            // gridAllowances
            // 
            this.gridAllowances.HeaderText = "Other Allowances";
            this.gridAllowances.Name = "gridAllowances";
            this.gridAllowances.ReadOnly = true;
            // 
            // gridMedicalClaims
            // 
            this.gridMedicalClaims.HeaderText = "Medical Claims";
            this.gridMedicalClaims.Name = "gridMedicalClaims";
            this.gridMedicalClaims.ReadOnly = true;
            // 
            // gridArrears
            // 
            this.gridArrears.HeaderText = "Arrears";
            this.gridArrears.Name = "gridArrears";
            this.gridArrears.ReadOnly = true;
            // 
            // gridTotalOverTimes
            // 
            this.gridTotalOverTimes.HeaderText = "Total OverTime";
            this.gridTotalOverTimes.Name = "gridTotalOverTimes";
            this.gridTotalOverTimes.ReadOnly = true;
            // 
            // gridTotalOverTimeHours
            // 
            this.gridTotalOverTimeHours.HeaderText = "Total OverTime Hrs";
            this.gridTotalOverTimeHours.Name = "gridTotalOverTimeHours";
            this.gridTotalOverTimeHours.ReadOnly = true;
            // 
            // gridGrandTotalAllowance
            // 
            this.gridGrandTotalAllowance.HeaderText = "TotalAllowance";
            this.gridGrandTotalAllowance.Name = "gridGrandTotalAllowance";
            this.gridGrandTotalAllowance.ReadOnly = true;
            // 
            // gridGrossSalary
            // 
            this.gridGrossSalary.HeaderText = "Gross Salary";
            this.gridGrossSalary.Name = "gridGrossSalary";
            this.gridGrossSalary.ReadOnly = true;
            // 
            // gridSNNITEmployee
            // 
            this.gridSNNITEmployee.HeaderText = "SSNIT (Employee)";
            this.gridSNNITEmployee.Name = "gridSNNITEmployee";
            this.gridSNNITEmployee.ReadOnly = true;
            // 
            // gridProvidentFundEmployee
            // 
            this.gridProvidentFundEmployee.HeaderText = "Provident Fund Employee";
            this.gridProvidentFundEmployee.Name = "gridProvidentFundEmployee";
            this.gridProvidentFundEmployee.ReadOnly = true;
            // 
            // gridProvidentFundEmployer
            // 
            this.gridProvidentFundEmployer.HeaderText = "Provident Fund Employer";
            this.gridProvidentFundEmployer.Name = "gridProvidentFundEmployer";
            this.gridProvidentFundEmployer.ReadOnly = true;
            // 
            // gridTotalTaxAllowance
            // 
            this.gridTotalTaxAllowance.HeaderText = "Total Tax Allow.";
            this.gridTotalTaxAllowance.Name = "gridTotalTaxAllowance";
            this.gridTotalTaxAllowance.ReadOnly = true;
            // 
            // gridTaxableIncome
            // 
            this.gridTaxableIncome.HeaderText = "Taxable Income";
            this.gridTaxableIncome.Name = "gridTaxableIncome";
            this.gridTaxableIncome.ReadOnly = true;
            // 
            // gridWithholdingTaxRate
            // 
            this.gridWithholdingTaxRate.HeaderText = "Withholding Tax (%)";
            this.gridWithholdingTaxRate.Name = "gridWithholdingTaxRate";
            this.gridWithholdingTaxRate.ReadOnly = true;
            // 
            // gridWithholdingTaxCalculateOn
            // 
            this.gridWithholdingTaxCalculateOn.HeaderText = "WithholdingTaxCalculateOn";
            this.gridWithholdingTaxCalculateOn.Name = "gridWithholdingTaxCalculateOn";
            this.gridWithholdingTaxCalculateOn.ReadOnly = true;
            // 
            // gridWithholdingAmount
            // 
            this.gridWithholdingAmount.HeaderText = "Withholding Amount";
            this.gridWithholdingAmount.Name = "gridWithholdingAmount";
            this.gridWithholdingAmount.ReadOnly = true;
            // 
            // gridWithholdingTaxFixedAmount
            // 
            this.gridWithholdingTaxFixedAmount.HeaderText = "Withholding Fixed Amount";
            this.gridWithholdingTaxFixedAmount.Name = "gridWithholdingTaxFixedAmount";
            this.gridWithholdingTaxFixedAmount.ReadOnly = true;
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
            // gridSusuPlusContribution
            // 
            this.gridSusuPlusContribution.HeaderText = "Susu Plus Contribution";
            this.gridSusuPlusContribution.Name = "gridSusuPlusContribution";
            this.gridSusuPlusContribution.ReadOnly = true;
            // 
            // gridDeductions
            // 
            this.gridDeductions.HeaderText = "Other Deductions";
            this.gridDeductions.Name = "gridDeductions";
            this.gridDeductions.ReadOnly = true;
            // 
            // gridLoan
            // 
            this.gridLoan.HeaderText = "Monthly Deduction";
            this.gridLoan.Name = "gridLoan";
            this.gridLoan.ReadOnly = true;
            // 
            // gridInitialLoan
            // 
            this.gridInitialLoan.HeaderText = "Loan Amount";
            this.gridInitialLoan.Name = "gridInitialLoan";
            this.gridInitialLoan.ReadOnly = true;
            // 
            // gridGrandTotalDeduction
            // 
            this.gridGrandTotalDeduction.HeaderText = "TotalDeduction";
            this.gridGrandTotalDeduction.Name = "gridGrandTotalDeduction";
            this.gridGrandTotalDeduction.ReadOnly = true;
            // 
            // gridNetSalary
            // 
            this.gridNetSalary.HeaderText = "Net Salary";
            this.gridNetSalary.Name = "gridNetSalary";
            this.gridNetSalary.ReadOnly = true;
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
            // gridSSNITFirstTier
            // 
            this.gridSSNITFirstTier.HeaderText = "1st Tier";
            this.gridSSNITFirstTier.Name = "gridSSNITFirstTier";
            this.gridSSNITFirstTier.ReadOnly = true;
            // 
            // gridSecondTier
            // 
            this.gridSecondTier.HeaderText = "2nd Tier";
            this.gridSecondTier.Name = "gridSecondTier";
            this.gridSecondTier.ReadOnly = true;
            // 
            // gridEmail
            // 
            this.gridEmail.HeaderText = "Email";
            this.gridEmail.Name = "gridEmail";
            this.gridEmail.ReadOnly = true;
            // 
            // gridMobileNumber
            // 
            this.gridMobileNumber.HeaderText = "MobileNo";
            this.gridMobileNumber.Name = "gridMobileNumber";
            this.gridMobileNumber.ReadOnly = true;
            // 
            // gridStatus
            // 
            this.gridStatus.HeaderText = "Status";
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.ReadOnly = true;
            // 
            // gridMechanised
            // 
            this.gridMechanised.HeaderText = "Mechanised";
            this.gridMechanised.Name = "gridMechanised";
            this.gridMechanised.ReadOnly = true;
            // 
            // PayrollGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1143, 611);
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
            this.attendanceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Button btnClosePayRoll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox periodGroupBox;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.Button btnLoanPayments;
        private System.Windows.Forms.Button btnMedicalClaim;
        private System.Windows.Forms.Button btnAllowances;
        private System.Windows.Forms.Button btnDeductions;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox staffIDTextBox;
        private System.Windows.Forms.Button btnViewSelectedSlips;
        private System.Windows.Forms.Button btnViewPayRoll;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.Button btnSalaryInfo;
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
        private System.Windows.Forms.Button btnPrintPayRoll;
        private System.Windows.Forms.Button payRollButton;
        private System.Windows.Forms.Button btnOpenPayRoll;
        private System.Windows.Forms.Button btnDeletePayRoll;
        private System.Windows.Forms.Button btnPrintAllSlips;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.Button btnEmailAll;
        private System.Windows.Forms.Button btnEmailSelected;
        private System.Windows.Forms.ComboBox cmbFileFomats;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalAllowance;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.TextBox txtNoPayrollStaff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSSNIT;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtIncomeTax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTotalDeduction;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTaxableIncome;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNetPay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTotalLoan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtGrossIncome;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSMSSelected;
        private System.Windows.Forms.Button btnSMS;
        private System.Windows.Forms.ComboBox cboMechanised;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1StaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1StaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1MobileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1Mechanised;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1AttendanceDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.TextBox txtProvidentFundEmployee;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtProvidentFundEmployer;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxExemptOtherDeductions;
        private System.Windows.Forms.CheckBox checkBoxExemptAllowances;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtTotalSalaryEarned;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
        private System.Windows.Forms.TextBox txtSSNITER;
        private System.Windows.Forms.Label label25;
        private eMAS.Forms.Reports.PayRollRegisterOldFormat payRollRegisterOldFormat1;
        private eMAS.Forms.Reports.PaySlipReport paySlipReport1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPaymentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAttendanceDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridBasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridActualBasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAllowances;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMedicalClaims;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridArrears;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTotalOverTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTotalOverTimeHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGrandTotalAllowance;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGrossSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSNNITEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridProvidentFundEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridProvidentFundEmployer;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTotalTaxAllowance;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTaxableIncome;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridWithholdingTaxRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridWithholdingTaxCalculateOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridWithholdingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridWithholdingTaxFixedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIncomeTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNetAfterTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSusuPlusContribution;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDeductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridInitialLoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGrandTotalDeduction;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNetSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTakeHome;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSSNITNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGradeLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSSNITEmployer;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSSNITFirstTier;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSecondTier;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMobileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMechanised;
    }
}