namespace eMAS.Forms.PayRollProcessing
{
    partial class ArrearsView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.effectiveDatePicker = new System.Windows.Forms.DateTimePicker();
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
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCurrentSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPreviousSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridNumberOfTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEffectiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSSNIT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridIncomeTax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridInUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.gridStaffCode,
            this.gridAge,
            this.gridGender,
            this.gridStaffID,
            this.gridStaffName,
            this.gridCurrentSalary,
            this.gridPreviousSalary,
            this.gridType,
            this.gridNumberOfTimes,
            this.gridEffectiveDate,
            this.gridSSNIT,
            this.gridIncomeTax,
            this.gridInUse,
            this.gridReason,
            this.gridUserID});
            this.grid.Location = new System.Drawing.Point(8, 135);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 21;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(645, 225);
            this.grid.TabIndex = 31;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
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
            this.panel1.Size = new System.Drawing.Size(668, 33);
            this.panel1.TabIndex = 30;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(251, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(332, 5);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(398, 5);
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
            this.panel2.Size = new System.Drawing.Size(668, 24);
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
            this.label13.Text = "All Medical Cliams";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "Effective Date:";
            // 
            // effectiveDatePicker
            // 
            this.effectiveDatePicker.Checked = false;
            this.effectiveDatePicker.CustomFormat = "dd/MM/yyyy";
            this.effectiveDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.effectiveDatePicker.Location = new System.Drawing.Point(85, 109);
            this.effectiveDatePicker.MaxDate = new System.DateTime(2015, 2, 19, 0, 0, 0, 0);
            this.effectiveDatePicker.Name = "effectiveDatePicker";
            this.effectiveDatePicker.ShowCheckBox = true;
            this.effectiveDatePicker.Size = new System.Drawing.Size(137, 20);
            this.effectiveDatePicker.TabIndex = 57;
            this.effectiveDatePicker.Value = new System.DateTime(2015, 2, 19, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(243, 85);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 20);
            this.txtFirstName.TabIndex = 55;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(580, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 45);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(425, 84);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(144, 20);
            this.txtSurname.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Surname : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "StaffID : ";
            // 
            // txtStaffID
            // 
            this.txtStaffID.Location = new System.Drawing.Point(85, 83);
            this.txtStaffID.Name = "txtStaffID";
            this.txtStaffID.Size = new System.Drawing.Size(96, 20);
            this.txtStaffID.TabIndex = 50;
            this.txtStaffID.TextChanged += new System.EventHandler(this.txtStaffID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Unit : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Department :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Grade Category :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Grade : ";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(85, 56);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(204, 21);
            this.cboUnit.TabIndex = 45;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(85, 30);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(204, 21);
            this.cboDepartment.TabIndex = 44;
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(384, 57);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(184, 21);
            this.cboGrade.TabIndex = 43;
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(384, 30);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(184, 21);
            this.cboGradeCategory.TabIndex = 42;
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
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
            this.dataGridViewTextBoxColumn6.Width = 150;
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
            // gridGender
            // 
            this.gridGender.HeaderText = "Sex";
            this.gridGender.Name = "gridGender";
            this.gridGender.ReadOnly = true;
            this.gridGender.Visible = false;
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
            this.gridStaffName.Width = 150;
            // 
            // gridCurrentSalary
            // 
            this.gridCurrentSalary.HeaderText = "Cur. Salary";
            this.gridCurrentSalary.Name = "gridCurrentSalary";
            this.gridCurrentSalary.ReadOnly = true;
            // 
            // gridPreviousSalary
            // 
            this.gridPreviousSalary.HeaderText = "Prev. Salary";
            this.gridPreviousSalary.Name = "gridPreviousSalary";
            this.gridPreviousSalary.ReadOnly = true;
            // 
            // gridType
            // 
            this.gridType.HeaderText = "Type";
            this.gridType.Name = "gridType";
            this.gridType.ReadOnly = true;
            // 
            // gridNumberOfTimes
            // 
            this.gridNumberOfTimes.HeaderText = "No. of Times";
            this.gridNumberOfTimes.Name = "gridNumberOfTimes";
            this.gridNumberOfTimes.ReadOnly = true;
            // 
            // gridEffectiveDate
            // 
            this.gridEffectiveDate.HeaderText = "Effective Date";
            this.gridEffectiveDate.Name = "gridEffectiveDate";
            this.gridEffectiveDate.ReadOnly = true;
            // 
            // gridSSNIT
            // 
            this.gridSSNIT.HeaderText = "SSNIT";
            this.gridSSNIT.Name = "gridSSNIT";
            this.gridSSNIT.ReadOnly = true;
            this.gridSSNIT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSSNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridIncomeTax
            // 
            this.gridIncomeTax.HeaderText = "IncomeTax";
            this.gridIncomeTax.Name = "gridIncomeTax";
            this.gridIncomeTax.ReadOnly = true;
            this.gridIncomeTax.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridIncomeTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridInUse
            // 
            this.gridInUse.HeaderText = "In Use";
            this.gridInUse.Name = "gridInUse";
            this.gridInUse.ReadOnly = true;
            this.gridInUse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridReason
            // 
            this.gridReason.HeaderText = "Reason";
            this.gridReason.Name = "gridReason";
            this.gridReason.ReadOnly = true;
            // 
            // gridUserID
            // 
            this.gridUserID.HeaderText = "UserID";
            this.gridUserID.Name = "gridUserID";
            this.gridUserID.ReadOnly = true;
            this.gridUserID.Visible = false;
            // 
            // ArrearsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(665, 399);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.effectiveDatePicker);
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
            this.Name = "ArrearsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arrears View";
            this.Load += new System.EventHandler(this.ArrearsView_Load);
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
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker effectiveDatePicker;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCurrentSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPreviousSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNumberOfTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEffectiveDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridSSNIT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridIncomeTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridInUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
    }
}