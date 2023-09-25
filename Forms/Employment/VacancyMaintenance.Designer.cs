namespace eMAS.Forms.StaffInformation
{
    partial class Vacancy_Maintenance
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbQuickSearch = new System.Windows.Forms.Label();
            this.tbxQuickSearch = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEmployeeGradeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEmployeeGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAppointmentTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAppointmentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDate = new CalendarColumn();
            this.gridDeadline = new CalendarColumn();
            this.gridContactNos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFaxNos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPostalAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPMB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridVacancyDueTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new CalendarColumn();
            this.calendarColumn2 = new CalendarColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 361);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 37);
            this.panel1.TabIndex = 23;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(805, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(60, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(871, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbQuickSearch);
            this.panel2.Controls.Add(this.tbxQuickSearch);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(942, 37);
            this.panel2.TabIndex = 22;
            // 
            // lbQuickSearch
            // 
            this.lbQuickSearch.AutoSize = true;
            this.lbQuickSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuickSearch.ForeColor = System.Drawing.Color.White;
            this.lbQuickSearch.Location = new System.Drawing.Point(569, 10);
            this.lbQuickSearch.Name = "lbQuickSearch";
            this.lbQuickSearch.Size = new System.Drawing.Size(84, 13);
            this.lbQuickSearch.TabIndex = 2;
            this.lbQuickSearch.Text = "Quick Search";
            this.lbQuickSearch.Visible = false;
            // 
            // tbxQuickSearch
            // 
            this.tbxQuickSearch.Location = new System.Drawing.Point(659, 7);
            this.tbxQuickSearch.Name = "tbxQuickSearch";
            this.tbxQuickSearch.Size = new System.Drawing.Size(220, 20);
            this.tbxQuickSearch.TabIndex = 1;
            this.tbxQuickSearch.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Vacancy Maintenance";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridEmployeeGradeID,
            this.gridEmployeeGrade,
            this.gridAppointmentTypeID,
            this.gridAppointmentType,
            this.gridDepartmentID,
            this.gridDepartment,
            this.gridDate,
            this.gridDeadline,
            this.gridContactNos,
            this.gridFaxNos,
            this.gridEmailAddress,
            this.gridPostalAddress,
            this.gridPMB,
            this.gridVacancyDueTo,
            this.gridStatus,
            this.gridUserId});
            this.grid.Location = new System.Drawing.Point(7, 49);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(930, 306);
            this.grid.TabIndex = 25;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            // 
            // gridEmployeeGradeID
            // 
            this.gridEmployeeGradeID.HeaderText = "EmployeeGradeID";
            this.gridEmployeeGradeID.Name = "gridEmployeeGradeID";
            this.gridEmployeeGradeID.ReadOnly = true;
            this.gridEmployeeGradeID.Visible = false;
            // 
            // gridEmployeeGrade
            // 
            this.gridEmployeeGrade.HeaderText = "Grade";
            this.gridEmployeeGrade.Name = "gridEmployeeGrade";
            this.gridEmployeeGrade.ReadOnly = true;
            // 
            // gridAppointmentTypeID
            // 
            this.gridAppointmentTypeID.HeaderText = "AppointmentTypeID";
            this.gridAppointmentTypeID.Name = "gridAppointmentTypeID";
            this.gridAppointmentTypeID.ReadOnly = true;
            this.gridAppointmentTypeID.Visible = false;
            // 
            // gridAppointmentType
            // 
            this.gridAppointmentType.HeaderText = "AppointmentType";
            this.gridAppointmentType.Name = "gridAppointmentType";
            this.gridAppointmentType.ReadOnly = true;
            // 
            // gridDepartmentID
            // 
            this.gridDepartmentID.HeaderText = "DepartmentID";
            this.gridDepartmentID.Name = "gridDepartmentID";
            this.gridDepartmentID.ReadOnly = true;
            this.gridDepartmentID.Visible = false;
            // 
            // gridDepartment
            // 
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.ReadOnly = true;
            // 
            // gridDate
            // 
            this.gridDate.HeaderText = "Date";
            this.gridDate.Name = "gridDate";
            this.gridDate.ReadOnly = true;
            this.gridDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridDeadline
            // 
            this.gridDeadline.HeaderText = "DeadLine";
            this.gridDeadline.Name = "gridDeadline";
            this.gridDeadline.ReadOnly = true;
            this.gridDeadline.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDeadline.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridContactNos
            // 
            this.gridContactNos.HeaderText = "Contact Nos";
            this.gridContactNos.Name = "gridContactNos";
            this.gridContactNos.ReadOnly = true;
            // 
            // gridFaxNos
            // 
            this.gridFaxNos.HeaderText = "Fax Nos";
            this.gridFaxNos.Name = "gridFaxNos";
            this.gridFaxNos.ReadOnly = true;
            // 
            // gridEmailAddress
            // 
            this.gridEmailAddress.HeaderText = "Email Address";
            this.gridEmailAddress.Name = "gridEmailAddress";
            this.gridEmailAddress.ReadOnly = true;
            // 
            // gridPostalAddress
            // 
            this.gridPostalAddress.HeaderText = "Postal Address";
            this.gridPostalAddress.Name = "gridPostalAddress";
            this.gridPostalAddress.ReadOnly = true;
            // 
            // gridPMB
            // 
            this.gridPMB.HeaderText = "Private MailBag";
            this.gridPMB.Name = "gridPMB";
            this.gridPMB.ReadOnly = true;
            // 
            // gridVacancyDueTo
            // 
            this.gridVacancyDueTo.HeaderText = "Vacancy Due To";
            this.gridVacancyDueTo.Name = "gridVacancyDueTo";
            this.gridVacancyDueTo.ReadOnly = true;
            this.gridVacancyDueTo.Width = 120;
            // 
            // gridStatus
            // 
            this.gridStatus.HeaderText = "Status";
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.ReadOnly = true;
            // 
            // gridUserId
            // 
            this.gridUserId.HeaderText = "UserID";
            this.gridUserId.Name = "gridUserId";
            this.gridUserId.ReadOnly = true;
            this.gridUserId.Visible = false;
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
            this.dataGridViewTextBoxColumn2.HeaderText = "EmployeeGradeID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "DepartmentID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Job Title";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Type";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Job Description";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Department";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.HeaderText = "Date";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // calendarColumn2
            // 
            this.calendarColumn2.HeaderText = "DeadLine";
            this.calendarColumn2.Name = "calendarColumn2";
            this.calendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Vacancy Due To";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Minimum Education Level";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 200;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Work Experience";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Qualifications";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 120;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Email";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "DeadLine";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // Vacancy_Maintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(936, 396);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "Vacancy_Maintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vacancy_Maintenance";
            this.Load += new System.EventHandler(this.Vacancy_Maintenance_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lbQuickSearch;
        private System.Windows.Forms.TextBox tbxQuickSearch;
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
        private CalendarColumn calendarColumn1;
        private CalendarColumn calendarColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEmployeeGradeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEmployeeGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAppointmentTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAppointmentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private CalendarColumn gridDate;
        private CalendarColumn gridDeadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridContactNos;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFaxNos;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPostalAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPMB;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridVacancyDueTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserId;
        public System.Windows.Forms.Button btnRemove;
    }
}