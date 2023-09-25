namespace eMAS.Forms.EmployeeManagement
{
    partial class ExcuseDutyApprovalForm
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
            this.label11 = new System.Windows.Forms.Label();
            this.cboApproved = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStaffID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.datePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPreviewMedicalSheet = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboRequestType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.datePickerRequestDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGradeCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLeaveStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRequestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMedicalSheet = new System.Windows.Forms.DataGridViewLinkColumn();
            this.gridRequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridResumed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridResumptionReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridResumptionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRecommended = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridRecommendedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRecommendationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRecommendationRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridApproved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridApprovedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(418, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 108;
            this.label11.Text = "Approved:";
            // 
            // cboApproved
            // 
            this.cboApproved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApproved.FormattingEnabled = true;
            this.cboApproved.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboApproved.Location = new System.Drawing.Point(477, 12);
            this.cboApproved.Name = "cboApproved";
            this.cboApproved.Size = new System.Drawing.Size(58, 21);
            this.cboApproved.TabIndex = 107;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "StaffID : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 85;
            this.label10.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(335, 87);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(99, 20);
            this.txtFirstName.TabIndex = 86;
            // 
            // txtStaffID
            // 
            this.txtStaffID.Location = new System.Drawing.Point(487, 87);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.Size = new System.Drawing.Size(75, 20);
            this.txtStaffID.TabIndex = 71;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datePickerEndDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.datePickerStartDate);
            this.groupBox1.Location = new System.Drawing.Point(242, 103);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(389, 35);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            // 
            // datePickerEndDate
            // 
            this.datePickerEndDate.Checked = false;
            this.datePickerEndDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerEndDate.Location = new System.Drawing.Point(259, 12);
            this.datePickerEndDate.Name = "datePickerEndDate";
            this.datePickerEndDate.ShowCheckBox = true;
            this.datePickerEndDate.Size = new System.Drawing.Size(123, 20);
            this.datePickerEndDate.TabIndex = 103;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(203, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 102;
            this.label12.Text = "End Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 101;
            this.label9.Text = "Start Date:";
            // 
            // datePickerStartDate
            // 
            this.datePickerStartDate.Checked = false;
            this.datePickerStartDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerStartDate.Location = new System.Drawing.Point(94, 12);
            this.datePickerStartDate.Name = "datePickerStartDate";
            this.datePickerStartDate.ShowCheckBox = true;
            this.datePickerStartDate.Size = new System.Drawing.Size(99, 20);
            this.datePickerStartDate.TabIndex = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Unit:";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(90, 64);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(180, 21);
            this.cboUnit.TabIndex = 98;
            this.cboUnit.DropDown += new System.EventHandler(this.cboUnit_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Department:";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(90, 40);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(180, 21);
            this.cboDepartment.TabIndex = 96;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(540, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 71);
            this.btnSearch.TabIndex = 95;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 94;
            this.label14.Text = "Request Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 83;
            this.label7.Text = "Grade:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "Grade Category:";
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(362, 62);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(172, 21);
            this.cboGrade.TabIndex = 81;
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(362, 37);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(172, 21);
            this.cboGradeCategory.TabIndex = 80;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectedIndexChanged += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.btnPreviewMedicalSheet);
            this.panel2.Controls.Add(this.btnApprove);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnClearSelection);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(1, 484);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 37);
            this.panel2.TabIndex = 121;
            // 
            // btnPreviewMedicalSheet
            // 
            this.btnPreviewMedicalSheet.Location = new System.Drawing.Point(14, 7);
            this.btnPreviewMedicalSheet.Name = "btnPreviewMedicalSheet";
            this.btnPreviewMedicalSheet.Size = new System.Drawing.Size(176, 23);
            this.btnPreviewMedicalSheet.TabIndex = 36;
            this.btnPreviewMedicalSheet.Text = "Preview Medical Sheet";
            this.btnPreviewMedicalSheet.UseVisualStyleBackColor = true;
            this.btnPreviewMedicalSheet.Click += new System.EventHandler(this.btnPreviewMedicalSheet_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(325, 7);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(79, 23);
            this.btnApprove.TabIndex = 35;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(219, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 23);
            this.btnRefresh.TabIndex = 33;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(442, 7);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(96, 23);
            this.btnClearSelection.TabIndex = 27;
            this.btnClearSelection.Text = "Clear Selection";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(577, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboRequestType
            // 
            this.cboRequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRequestType.FormattingEnabled = true;
            this.cboRequestType.Location = new System.Drawing.Point(89, 110);
            this.cboRequestType.Name = "cboRequestType";
            this.cboRequestType.Size = new System.Drawing.Size(142, 21);
            this.cboRequestType.TabIndex = 93;
            this.cboRequestType.DropDown += new System.EventHandler(this.cboRequestType_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Surname : ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(-1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(639, 38);
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
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excused Duty Approval";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.BackColor = System.Drawing.Color.Lavender;
            this.groupBoxSearch.Controls.Add(this.label11);
            this.groupBoxSearch.Controls.Add(this.cboApproved);
            this.groupBoxSearch.Controls.Add(this.label5);
            this.groupBoxSearch.Controls.Add(this.label10);
            this.groupBoxSearch.Controls.Add(this.txtFirstName);
            this.groupBoxSearch.Controls.Add(this.txtStaffID);
            this.groupBoxSearch.Controls.Add(this.groupBox1);
            this.groupBoxSearch.Controls.Add(this.label2);
            this.groupBoxSearch.Controls.Add(this.cboUnit);
            this.groupBoxSearch.Controls.Add(this.label3);
            this.groupBoxSearch.Controls.Add(this.cboDepartment);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.label14);
            this.groupBoxSearch.Controls.Add(this.cboRequestType);
            this.groupBoxSearch.Controls.Add(this.label7);
            this.groupBoxSearch.Controls.Add(this.label4);
            this.groupBoxSearch.Controls.Add(this.cboGrade);
            this.groupBoxSearch.Controls.Add(this.cboGradeCategory);
            this.groupBoxSearch.Controls.Add(this.label6);
            this.groupBoxSearch.Controls.Add(this.txtSurname);
            this.groupBoxSearch.Controls.Add(this.label8);
            this.groupBoxSearch.Controls.Add(this.datePickerRequestDate);
            this.groupBoxSearch.Location = new System.Drawing.Point(3, 40);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(631, 149);
            this.groupBoxSearch.TabIndex = 119;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Filters";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(89, 88);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(142, 20);
            this.txtSurname.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 70;
            this.label8.Text = "Request Date:";
            // 
            // datePickerRequestDate
            // 
            this.datePickerRequestDate.Checked = false;
            this.datePickerRequestDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerRequestDate.Location = new System.Drawing.Point(90, 14);
            this.datePickerRequestDate.Name = "datePickerRequestDate";
            this.datePickerRequestDate.ShowCheckBox = true;
            this.datePickerRequestDate.Size = new System.Drawing.Size(141, 20);
            this.datePickerRequestDate.TabIndex = 69;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.Location = new System.Drawing.Point(0, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 283);
            this.groupBox2.TabIndex = 120;
            this.groupBox2.TabStop = false;
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
            this.gridStaffID,
            this.gridName,
            this.gridDepartment,
            this.gridUnit,
            this.gridGradeCategory,
            this.gridLeaveStatus,
            this.gridRequestType,
            this.gridMedicalSheet,
            this.gridRequestDate,
            this.gridStartDate,
            this.gridEndDate,
            this.gridResumed,
            this.gridResumptionReason,
            this.gridResumptionDate,
            this.gridRecommended,
            this.gridRecommendedBy,
            this.gridRecommendationDate,
            this.gridRecommendationRemarks,
            this.gridApproved,
            this.gridApprovedBy,
            this.gridApprovedOn});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 16);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 21;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(629, 264);
            this.grid.TabIndex = 32;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            // 
            // gridStaffID
            // 
            this.gridStaffID.HeaderText = "Staff ID";
            this.gridStaffID.Name = "gridStaffID";
            this.gridStaffID.ReadOnly = true;
            // 
            // gridName
            // 
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 150;
            // 
            // gridDepartment
            // 
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.ReadOnly = true;
            this.gridDepartment.Width = 130;
            // 
            // gridUnit
            // 
            this.gridUnit.HeaderText = "Unit";
            this.gridUnit.Name = "gridUnit";
            this.gridUnit.ReadOnly = true;
            // 
            // gridGradeCategory
            // 
            this.gridGradeCategory.HeaderText = "Grad Category";
            this.gridGradeCategory.Name = "gridGradeCategory";
            this.gridGradeCategory.ReadOnly = true;
            this.gridGradeCategory.Width = 130;
            // 
            // gridLeaveStatus
            // 
            this.gridLeaveStatus.HeaderText = "Leave Status";
            this.gridLeaveStatus.Name = "gridLeaveStatus";
            this.gridLeaveStatus.ReadOnly = true;
            this.gridLeaveStatus.Width = 130;
            // 
            // gridRequestType
            // 
            this.gridRequestType.HeaderText = "Request Type";
            this.gridRequestType.Name = "gridRequestType";
            this.gridRequestType.ReadOnly = true;
            this.gridRequestType.Width = 130;
            // 
            // gridMedicalSheet
            // 
            this.gridMedicalSheet.HeaderText = "Medical Sheet";
            this.gridMedicalSheet.Name = "gridMedicalSheet";
            this.gridMedicalSheet.ReadOnly = true;
            // 
            // gridRequestDate
            // 
            this.gridRequestDate.HeaderText = "Request Date";
            this.gridRequestDate.Name = "gridRequestDate";
            this.gridRequestDate.ReadOnly = true;
            // 
            // gridStartDate
            // 
            this.gridStartDate.HeaderText = "Start Date";
            this.gridStartDate.Name = "gridStartDate";
            this.gridStartDate.ReadOnly = true;
            // 
            // gridEndDate
            // 
            this.gridEndDate.HeaderText = "End Date";
            this.gridEndDate.Name = "gridEndDate";
            this.gridEndDate.ReadOnly = true;
            // 
            // gridResumed
            // 
            this.gridResumed.HeaderText = "Resumed";
            this.gridResumed.Name = "gridResumed";
            this.gridResumed.ReadOnly = true;
            // 
            // gridResumptionReason
            // 
            this.gridResumptionReason.HeaderText = "Resumption Reason";
            this.gridResumptionReason.Name = "gridResumptionReason";
            this.gridResumptionReason.ReadOnly = true;
            this.gridResumptionReason.Width = 200;
            // 
            // gridResumptionDate
            // 
            this.gridResumptionDate.HeaderText = "Resumption Date";
            this.gridResumptionDate.Name = "gridResumptionDate";
            this.gridResumptionDate.ReadOnly = true;
            this.gridResumptionDate.Width = 200;
            // 
            // gridRecommended
            // 
            this.gridRecommended.HeaderText = "Recommended";
            this.gridRecommended.Name = "gridRecommended";
            this.gridRecommended.ReadOnly = true;
            this.gridRecommended.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRecommended.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridRecommendedBy
            // 
            this.gridRecommendedBy.HeaderText = "Recommended By";
            this.gridRecommendedBy.Name = "gridRecommendedBy";
            this.gridRecommendedBy.ReadOnly = true;
            // 
            // gridRecommendationDate
            // 
            this.gridRecommendationDate.FillWeight = 150F;
            this.gridRecommendationDate.HeaderText = "Assessment Date";
            this.gridRecommendationDate.Name = "gridRecommendationDate";
            this.gridRecommendationDate.ReadOnly = true;
            this.gridRecommendationDate.Width = 130;
            // 
            // gridRecommendationRemarks
            // 
            this.gridRecommendationRemarks.HeaderText = "Additional Remarks";
            this.gridRecommendationRemarks.Name = "gridRecommendationRemarks";
            this.gridRecommendationRemarks.ReadOnly = true;
            this.gridRecommendationRemarks.Width = 200;
            // 
            // gridApproved
            // 
            this.gridApproved.HeaderText = "Approved";
            this.gridApproved.Name = "gridApproved";
            this.gridApproved.ReadOnly = true;
            this.gridApproved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridApproved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridApprovedBy
            // 
            this.gridApprovedBy.HeaderText = "Approved By";
            this.gridApprovedBy.Name = "gridApprovedBy";
            this.gridApprovedBy.ReadOnly = true;
            // 
            // gridApprovedOn
            // 
            this.gridApprovedOn.FillWeight = 120F;
            this.gridApprovedOn.HeaderText = "Approved On";
            this.gridApprovedOn.Name = "gridApprovedOn";
            this.gridApprovedOn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Staff ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Department";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Grad Category";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Leave Status";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 130;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Request Type";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 130;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Request Date";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Start Date";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "End Date";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Recommended By";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.FillWeight = 150F;
            this.dataGridViewTextBoxColumn13.HeaderText = "Recommended On";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 130;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Additional Remarks";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Approved By";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.FillWeight = 120F;
            this.dataGridViewTextBoxColumn16.HeaderText = "Approved On";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // ExcuseDutyApprovalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 522);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ExcuseDutyApprovalForm";
            this.Text = "Excuse Duty Approval Form";
            this.Load += new System.EventHandler(this.ExcuseDutyApprovalForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboApproved;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtStaffID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker datePickerEndDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker datePickerStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboRequestType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datePickerRequestDate;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView grid;
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
        private System.Windows.Forms.Button btnPreviewMedicalSheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGradeCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLeaveStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRequestType;
        private System.Windows.Forms.DataGridViewLinkColumn gridMedicalSheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEndDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridResumed;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridResumptionReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridResumptionDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridRecommended;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRecommendedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRecommendationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRecommendationRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridApprovedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridApprovedOn;
    }
}