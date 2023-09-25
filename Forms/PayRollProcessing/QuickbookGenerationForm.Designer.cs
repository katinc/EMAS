namespace eMAS.Forms.PayRollProcessing
{
    partial class QuickbookGenerationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblGradeCategory = new System.Windows.Forms.Label();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPost = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDebit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridGradeCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridQuickbookOverseer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccountDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccountHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartmentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnitCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDate = new CalendarColumn();
            this.gridActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPosted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.periodLabel = new System.Windows.Forms.Label();
            this.calendarColumn1 = new CalendarColumn();
            this.calendarColumn2 = new CalendarColumn();
            this.calendarColumn3 = new CalendarColumn();
            this.calendarColumn4 = new CalendarColumn();
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
            this.calendarColumn5 = new CalendarColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(295, 28);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(150, 21);
            this.cboGrade.TabIndex = 17;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblGrade.Location = new System.Drawing.Point(248, 32);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(42, 13);
            this.lblGrade.TabIndex = 16;
            this.lblGrade.Text = "Grade :";
            // 
            // lblGradeCategory
            // 
            this.lblGradeCategory.AutoSize = true;
            this.lblGradeCategory.Location = new System.Drawing.Point(233, 8);
            this.lblGradeCategory.Name = "lblGradeCategory";
            this.lblGradeCategory.Size = new System.Drawing.Size(55, 13);
            this.lblGradeCategory.TabIndex = 15;
            this.lblGradeCategory.Text = "Category :";
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(295, 3);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(150, 21);
            this.cboGradeCategory.TabIndex = 14;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(292, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Generate And Post Cost and Payables Quickbook ";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(479, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(66, 48);
            this.btnGenerate.TabIndex = 15;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(625, 487);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPost.Location = new System.Drawing.Point(234, 487);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(128, 24);
            this.btnPost.TabIndex = 14;
            this.btnPost.Text = "Post to Quickbook";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.txtDebit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCredit);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.btnGenerate);
            this.panel2.Controls.Add(this.yearComboBox);
            this.panel2.Controls.Add(this.monthComboBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.periodLabel);
            this.panel2.Controls.Add(this.cboGrade);
            this.panel2.Controls.Add(this.lblGrade);
            this.panel2.Controls.Add(this.lblGradeCategory);
            this.panel2.Controls.Add(this.cboGradeCategory);
            this.panel2.Location = new System.Drawing.Point(8, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(917, 451);
            this.panel2.TabIndex = 12;
            // 
            // txtDebit
            // 
            this.txtDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDebit.Location = new System.Drawing.Point(347, 424);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Size = new System.Drawing.Size(163, 20);
            this.txtDebit.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Debit:";
            // 
            // txtCredit
            // 
            this.txtCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCredit.Location = new System.Drawing.Point(96, 422);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(148, 20);
            this.txtCredit.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "Credit:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.Location = new System.Drawing.Point(7, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(899, 368);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // grid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.Color.DarkGray;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridSelect,
            this.gridGradeCategory,
            this.gridQuickbookOverseer,
            this.gridAccountCode,
            this.gridAccountDescription,
            this.gridAmount,
            this.gridAccountType,
            this.gridAccountHeader,
            this.gridType,
            this.gridReport,
            this.gridDepartmentCode,
            this.gridDepartment,
            this.gridUnitCode,
            this.gridUnit,
            this.gridMonth,
            this.gridYear,
            this.gridTransactionID,
            this.gridDate,
            this.gridActive,
            this.gridStatus,
            this.gridPosted,
            this.gridName,
            this.gridUserName});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 16);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(893, 349);
            this.grid.TabIndex = 51;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.Visible = false;
            this.gridID.Width = 50;
            // 
            // gridSelect
            // 
            this.gridSelect.HeaderText = "";
            this.gridSelect.Name = "gridSelect";
            this.gridSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridSelect.Width = 40;
            // 
            // gridGradeCategory
            // 
            this.gridGradeCategory.HeaderText = "GradeCategory";
            this.gridGradeCategory.Name = "gridGradeCategory";
            this.gridGradeCategory.ReadOnly = true;
            // 
            // gridQuickbookOverseer
            // 
            this.gridQuickbookOverseer.HeaderText = "QuickbookOverseer";
            this.gridQuickbookOverseer.Name = "gridQuickbookOverseer";
            this.gridQuickbookOverseer.ReadOnly = true;
            this.gridQuickbookOverseer.Width = 120;
            // 
            // gridAccountCode
            // 
            this.gridAccountCode.HeaderText = "Account Code";
            this.gridAccountCode.Name = "gridAccountCode";
            this.gridAccountCode.ReadOnly = true;
            // 
            // gridAccountDescription
            // 
            this.gridAccountDescription.HeaderText = "AccountDescription";
            this.gridAccountDescription.Name = "gridAccountDescription";
            this.gridAccountDescription.ReadOnly = true;
            this.gridAccountDescription.Width = 150;
            // 
            // gridAmount
            // 
            this.gridAmount.HeaderText = "Amount";
            this.gridAmount.Name = "gridAmount";
            this.gridAmount.ReadOnly = true;
            this.gridAmount.Width = 60;
            // 
            // gridAccountType
            // 
            this.gridAccountType.HeaderText = "AccountType";
            this.gridAccountType.Name = "gridAccountType";
            this.gridAccountType.ReadOnly = true;
            // 
            // gridAccountHeader
            // 
            this.gridAccountHeader.HeaderText = "AccountHeader";
            this.gridAccountHeader.Name = "gridAccountHeader";
            this.gridAccountHeader.ReadOnly = true;
            // 
            // gridType
            // 
            this.gridType.HeaderText = "Type";
            this.gridType.Name = "gridType";
            this.gridType.ReadOnly = true;
            // 
            // gridReport
            // 
            this.gridReport.HeaderText = "Report";
            this.gridReport.Name = "gridReport";
            this.gridReport.ReadOnly = true;
            // 
            // gridDepartmentCode
            // 
            this.gridDepartmentCode.HeaderText = "Dept Code";
            this.gridDepartmentCode.Name = "gridDepartmentCode";
            this.gridDepartmentCode.ReadOnly = true;
            // 
            // gridDepartment
            // 
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.ReadOnly = true;
            // 
            // gridUnitCode
            // 
            this.gridUnitCode.HeaderText = "Unit Code";
            this.gridUnitCode.Name = "gridUnitCode";
            this.gridUnitCode.ReadOnly = true;
            // 
            // gridUnit
            // 
            this.gridUnit.HeaderText = "Unit";
            this.gridUnit.Name = "gridUnit";
            this.gridUnit.ReadOnly = true;
            this.gridUnit.Width = 150;
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
            // gridTransactionID
            // 
            this.gridTransactionID.HeaderText = "TxnID";
            this.gridTransactionID.Name = "gridTransactionID";
            // 
            // gridDate
            // 
            this.gridDate.HeaderText = "Date";
            this.gridDate.Name = "gridDate";
            this.gridDate.ReadOnly = true;
            // 
            // gridActive
            // 
            this.gridActive.HeaderText = "Active";
            this.gridActive.Name = "gridActive";
            this.gridActive.ReadOnly = true;
            this.gridActive.Width = 60;
            // 
            // gridStatus
            // 
            this.gridStatus.HeaderText = "Status";
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.ReadOnly = true;
            // 
            // gridPosted
            // 
            this.gridPosted.HeaderText = "Posted";
            this.gridPosted.Name = "gridPosted";
            this.gridPosted.ReadOnly = true;
            // 
            // gridName
            // 
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            // 
            // gridUserName
            // 
            this.gridUserName.HeaderText = "UserName";
            this.gridUserName.Name = "gridUserName";
            this.gridUserName.ReadOnly = true;
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(58, 29);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(153, 21);
            this.yearComboBox.TabIndex = 91;
            this.yearComboBox.DropDown += new System.EventHandler(this.yearComboBox_DropDown);
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(58, 6);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(153, 21);
            this.monthComboBox.TabIndex = 90;
            this.monthComboBox.DropDown += new System.EventHandler(this.monthComboBox_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(22, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Year:";
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.BackColor = System.Drawing.Color.Transparent;
            this.periodLabel.Location = new System.Drawing.Point(15, 10);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(40, 13);
            this.periodLabel.TabIndex = 89;
            this.periodLabel.Text = "Month:";
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.HeaderText = "Date";
            this.calendarColumn1.Name = "calendarColumn1";
            // 
            // calendarColumn2
            // 
            this.calendarColumn2.HeaderText = "Date";
            this.calendarColumn2.Name = "calendarColumn2";
            // 
            // calendarColumn3
            // 
            this.calendarColumn3.HeaderText = "Date";
            this.calendarColumn3.Name = "calendarColumn3";
            // 
            // calendarColumn4
            // 
            this.calendarColumn4.HeaderText = "Date";
            this.calendarColumn4.Name = "calendarColumn4";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "GradeCategory";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "AccountDescription";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "AccountType";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Report";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Query";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 250;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Overseer";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "QuickbookOverseer";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 60;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "QuickbookOverseer";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "UserName";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // calendarColumn5
            // 
            this.calendarColumn5.HeaderText = "Date";
            this.calendarColumn5.Name = "calendarColumn5";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(544, 488);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 34;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(365, 488);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 33;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearSelection.Location = new System.Drawing.Point(444, 488);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(96, 23);
            this.btnClearSelection.TabIndex = 32;
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // QuickbookGenerationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(934, 515);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClearSelection);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "QuickbookGenerationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quickbook Generation Form";
            this.Load += new System.EventHandler(this.QuickbookGenerationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblGradeCategory;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid;
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
        private CalendarColumn calendarColumn1;
        private CalendarColumn calendarColumn2;
        private CalendarColumn calendarColumn3;
        private CalendarColumn calendarColumn4;
        private CalendarColumn calendarColumn5;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.TextBox txtDebit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGradeCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridQuickbookOverseer;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccountDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccountHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartmentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUnitCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTransactionID;
        private CalendarColumn gridDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPosted;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserName;
    }
}