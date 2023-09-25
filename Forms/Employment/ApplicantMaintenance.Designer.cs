namespace eMAS.Forms.StaffInformation
{
    partial class ApplicantMaintenance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridVacancyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridVacancy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridContactAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridApplicationDate = new CalendarColumn();
            this.gridShortList = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new CalendarColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboVacancy = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabOtherDetails = new System.Windows.Forms.TabControl();
            this.documentsTabPage = new System.Windows.Forms.TabPage();
            this.gridDocuments = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDateCreated = new CalendarColumn();
            this.gridDocumentsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridEmploymentHistory = new System.Windows.Forms.DataGridView();
            this.gridEmploymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridNameOfOrganization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridJobTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFromMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFromYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridToMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridToYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridEducationHistory = new System.Windows.Forms.DataGridView();
            this.gridEducationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEducationNameOfInstitution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEducationCertificateObtained = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEducationFromMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEducationFromYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEducationToMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEducationToYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gridReferees = new System.Windows.Forms.DataGridView();
            this.gridRefereesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRefereesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRefereesOccupation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRefereesCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRefereesTelno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gridSkill = new System.Windows.Forms.DataGridView();
            this.gridSkillsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSkills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refereesCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOccupation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationsToYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsToMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsFromYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsFromMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsCertificateObtained = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationsNameOfInstitution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceToYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceToMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceFromYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceFromMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceJobTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceNameOfOrganisation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.tabOtherDetails.SuspendLayout();
            this.documentsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmploymentHistory)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEducationHistory)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReferees)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSkill)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 452);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 42);
            this.panel1.TabIndex = 23;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(534, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(600, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(60, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(666, 5);
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
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 32);
            this.panel2.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(17, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Applicants";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Location = new System.Drawing.Point(15, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 195);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
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
            this.gridVacancyID,
            this.gridVacancy,
            this.gridFirstName,
            this.gridMiddleName,
            this.gridSurname,
            this.gridContactAddress,
            this.gridContactNo,
            this.gridEmailAddress,
            this.gridApplicationDate,
            this.gridShortList,
            this.gridUserID});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 16);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 21;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(741, 176);
            this.grid.TabIndex = 25;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_Click);
            this.grid.Click += new System.EventHandler(this.grid_Click);
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.Visible = false;
            // 
            // gridVacancyID
            // 
            this.gridVacancyID.HeaderText = "VacancyID";
            this.gridVacancyID.Name = "gridVacancyID";
            this.gridVacancyID.Visible = false;
            this.gridVacancyID.Width = 50;
            // 
            // gridVacancy
            // 
            this.gridVacancy.HeaderText = "Vacancy";
            this.gridVacancy.Name = "gridVacancy";
            this.gridVacancy.ReadOnly = true;
            this.gridVacancy.Width = 143;
            // 
            // gridFirstName
            // 
            this.gridFirstName.HeaderText = "First Name";
            this.gridFirstName.Name = "gridFirstName";
            this.gridFirstName.ReadOnly = true;
            // 
            // gridMiddleName
            // 
            this.gridMiddleName.HeaderText = "Middle Name";
            this.gridMiddleName.Name = "gridMiddleName";
            this.gridMiddleName.ReadOnly = true;
            // 
            // gridSurname
            // 
            this.gridSurname.HeaderText = "Surname";
            this.gridSurname.Name = "gridSurname";
            this.gridSurname.ReadOnly = true;
            // 
            // gridContactAddress
            // 
            this.gridContactAddress.HeaderText = "Contact Address";
            this.gridContactAddress.Name = "gridContactAddress";
            this.gridContactAddress.ReadOnly = true;
            this.gridContactAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridContactAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridContactAddress.Visible = false;
            // 
            // gridContactNo
            // 
            this.gridContactNo.HeaderText = "Contact No";
            this.gridContactNo.Name = "gridContactNo";
            this.gridContactNo.ReadOnly = true;
            // 
            // gridEmailAddress
            // 
            this.gridEmailAddress.HeaderText = "Email";
            this.gridEmailAddress.Name = "gridEmailAddress";
            this.gridEmailAddress.ReadOnly = true;
            // 
            // gridApplicationDate
            // 
            this.gridApplicationDate.HeaderText = "Application Date";
            this.gridApplicationDate.Name = "gridApplicationDate";
            this.gridApplicationDate.ReadOnly = true;
            this.gridApplicationDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridApplicationDate.Visible = false;
            // 
            // gridShortList
            // 
            this.gridShortList.HeaderText = "Short List";
            this.gridShortList.Name = "gridShortList";
            this.gridShortList.Width = 60;
            // 
            // gridUserID
            // 
            this.gridUserID.HeaderText = "UserID";
            this.gridUserID.Name = "gridUserID";
            this.gridUserID.Visible = false;
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn2.HeaderText = "VacancyID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Vacancy";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DocumentType";
            this.dataGridViewTextBoxColumn4.HeaderText = "First Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Middle Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 123;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Surname";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 197;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Rating";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Comments";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 201;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "CV";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 123;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.HeaderText = "Application Date";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Cover Letter";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 109;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Middle Name";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Surname";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "CV";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 123;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Cover Letter";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Email";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Contact No";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Comments";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 201;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Rating";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 60;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(298, 35);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(160, 20);
            this.txtSurname.TabIndex = 29;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(530, 35);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(159, 20);
            this.txtFirstName.TabIndex = 30;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(298, 61);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(160, 20);
            this.txtMiddleName.TabIndex = 31;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(530, 61);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(159, 20);
            this.txtContactNo.TabIndex = 32;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(63, 61);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(153, 20);
            this.txtEmail.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "FirstName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Vacancy:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Surname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Middle Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(461, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Contact No:";
            // 
            // cboVacancy
            // 
            this.cboVacancy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVacancy.FormattingEnabled = true;
            this.cboVacancy.Location = new System.Drawing.Point(63, 36);
            this.cboVacancy.Name = "cboVacancy";
            this.cboVacancy.Size = new System.Drawing.Size(153, 21);
            this.cboVacancy.TabIndex = 41;
            this.cboVacancy.DropDown += new System.EventHandler(this.cboVacancy_DropDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(692, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 47);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabOtherDetails
            // 
            this.tabOtherDetails.Controls.Add(this.documentsTabPage);
            this.tabOtherDetails.Controls.Add(this.tabPage1);
            this.tabOtherDetails.Controls.Add(this.tabPage2);
            this.tabOtherDetails.Controls.Add(this.tabPage3);
            this.tabOtherDetails.Controls.Add(this.tabPage4);
            this.tabOtherDetails.Location = new System.Drawing.Point(15, 289);
            this.tabOtherDetails.Name = "tabOtherDetails";
            this.tabOtherDetails.SelectedIndex = 0;
            this.tabOtherDetails.Size = new System.Drawing.Size(744, 157);
            this.tabOtherDetails.TabIndex = 43;
            // 
            // documentsTabPage
            // 
            this.documentsTabPage.Controls.Add(this.gridDocuments);
            this.documentsTabPage.Location = new System.Drawing.Point(4, 22);
            this.documentsTabPage.Name = "documentsTabPage";
            this.documentsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.documentsTabPage.Size = new System.Drawing.Size(736, 131);
            this.documentsTabPage.TabIndex = 17;
            this.documentsTabPage.Text = "Documents";
            this.documentsTabPage.UseVisualStyleBackColor = true;
            // 
            // gridDocuments
            // 
            this.gridDocuments.AllowUserToAddRows = false;
            this.gridDocuments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.gridDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDocuments.BackgroundColor = System.Drawing.Color.SlateGray;
            this.gridDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn19,
            this.gridDocumentsDateCreated,
            this.gridDocumentsDescription,
            this.gridDocumentsDocumentGroup,
            this.gridDocumentsPath,
            this.gridDocumentsDocumentContent,
            this.dataGridViewTextBoxColumn26});
            this.gridDocuments.GridColor = System.Drawing.SystemColors.Control;
            this.gridDocuments.Location = new System.Drawing.Point(6, 6);
            this.gridDocuments.Name = "gridDocuments";
            this.gridDocuments.ReadOnly = true;
            this.gridDocuments.RowHeadersWidth = 23;
            this.gridDocuments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDocuments.Size = new System.Drawing.Size(721, 102);
            this.gridDocuments.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "ID";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Visible = false;
            // 
            // gridDocumentsDateCreated
            // 
            this.gridDocumentsDateCreated.DataPropertyName = "DateCreated";
            this.gridDocumentsDateCreated.HeaderText = "Date Created";
            this.gridDocumentsDateCreated.Name = "gridDocumentsDateCreated";
            this.gridDocumentsDateCreated.ReadOnly = true;
            this.gridDocumentsDateCreated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDocumentsDateCreated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridDocumentsDescription
            // 
            this.gridDocumentsDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridDocumentsDescription.DataPropertyName = "Description";
            this.gridDocumentsDescription.HeaderText = "Description";
            this.gridDocumentsDescription.Name = "gridDocumentsDescription";
            this.gridDocumentsDescription.ReadOnly = true;
            // 
            // gridDocumentsDocumentGroup
            // 
            this.gridDocumentsDocumentGroup.HeaderText = "Document Group";
            this.gridDocumentsDocumentGroup.Name = "gridDocumentsDocumentGroup";
            this.gridDocumentsDocumentGroup.ReadOnly = true;
            this.gridDocumentsDocumentGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDocumentsDocumentGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridDocumentsDocumentGroup.Width = 160;
            // 
            // gridDocumentsPath
            // 
            this.gridDocumentsPath.HeaderText = "Path";
            this.gridDocumentsPath.Name = "gridDocumentsPath";
            this.gridDocumentsPath.ReadOnly = true;
            this.gridDocumentsPath.Width = 180;
            // 
            // gridDocumentsDocumentContent
            // 
            this.gridDocumentsDocumentContent.HeaderText = "DocumentContent";
            this.gridDocumentsDocumentContent.Name = "gridDocumentsDocumentContent";
            this.gridDocumentsDocumentContent.ReadOnly = true;
            this.gridDocumentsDocumentContent.Visible = false;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.HeaderText = "UserID";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridEmploymentHistory);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(736, 131);
            this.tabPage1.TabIndex = 18;
            this.tabPage1.Text = "Employment History";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridEmploymentHistory
            // 
            this.gridEmploymentHistory.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridEmploymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmploymentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridEmploymentID,
            this.gridNameOfOrganization,
            this.gridJobTitle,
            this.gridFromMonth,
            this.gridFromYear,
            this.gridToMonth,
            this.gridToYear});
            this.gridEmploymentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmploymentHistory.GridColor = System.Drawing.Color.Gainsboro;
            this.gridEmploymentHistory.Location = new System.Drawing.Point(3, 3);
            this.gridEmploymentHistory.Name = "gridEmploymentHistory";
            this.gridEmploymentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmploymentHistory.Size = new System.Drawing.Size(730, 125);
            this.gridEmploymentHistory.TabIndex = 2;
            // 
            // gridEmploymentID
            // 
            this.gridEmploymentID.HeaderText = "ID";
            this.gridEmploymentID.Name = "gridEmploymentID";
            this.gridEmploymentID.Visible = false;
            // 
            // gridNameOfOrganization
            // 
            this.gridNameOfOrganization.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridNameOfOrganization.FillWeight = 2F;
            this.gridNameOfOrganization.HeaderText = "Name of Organisation";
            this.gridNameOfOrganization.Name = "gridNameOfOrganization";
            // 
            // gridJobTitle
            // 
            this.gridJobTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridJobTitle.DataPropertyName = "JobDescription";
            this.gridJobTitle.FillWeight = 1.5F;
            this.gridJobTitle.HeaderText = "Job Title";
            this.gridJobTitle.Name = "gridJobTitle";
            // 
            // gridFromMonth
            // 
            this.gridFromMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridFromMonth.FillWeight = 1F;
            this.gridFromMonth.HeaderText = "From (Month)";
            this.gridFromMonth.Name = "gridFromMonth";
            this.gridFromMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFromMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridFromYear
            // 
            this.gridFromYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridFromYear.DataPropertyName = "From";
            this.gridFromYear.FillWeight = 1F;
            this.gridFromYear.HeaderText = "From (Year)";
            this.gridFromYear.Name = "gridFromYear";
            this.gridFromYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gridToMonth
            // 
            this.gridToMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridToMonth.FillWeight = 1F;
            this.gridToMonth.HeaderText = "To (Month)";
            this.gridToMonth.Name = "gridToMonth";
            this.gridToMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridToMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridToYear
            // 
            this.gridToYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridToYear.DataPropertyName = "To";
            this.gridToYear.FillWeight = 1F;
            this.gridToYear.HeaderText = "To (Year)";
            this.gridToYear.Name = "gridToYear";
            this.gridToYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridEducationHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(736, 131);
            this.tabPage2.TabIndex = 19;
            this.tabPage2.Text = "Education History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridEducationHistory
            // 
            this.gridEducationHistory.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridEducationHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEducationHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridEducationID,
            this.gridEducationNameOfInstitution,
            this.gridEducationCertificateObtained,
            this.gridEducationFromMonth,
            this.gridEducationFromYear,
            this.gridEducationToMonth,
            this.gridEducationToYear});
            this.gridEducationHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEducationHistory.GridColor = System.Drawing.Color.Gainsboro;
            this.gridEducationHistory.Location = new System.Drawing.Point(3, 3);
            this.gridEducationHistory.Name = "gridEducationHistory";
            this.gridEducationHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEducationHistory.Size = new System.Drawing.Size(730, 125);
            this.gridEducationHistory.TabIndex = 2;
            // 
            // gridEducationID
            // 
            this.gridEducationID.HeaderText = "ID";
            this.gridEducationID.Name = "gridEducationID";
            this.gridEducationID.Visible = false;
            // 
            // gridEducationNameOfInstitution
            // 
            this.gridEducationNameOfInstitution.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridEducationNameOfInstitution.DataPropertyName = "NameOfInstitution";
            this.gridEducationNameOfInstitution.FillWeight = 2F;
            this.gridEducationNameOfInstitution.HeaderText = "Name of Institution";
            this.gridEducationNameOfInstitution.Name = "gridEducationNameOfInstitution";
            // 
            // gridEducationCertificateObtained
            // 
            this.gridEducationCertificateObtained.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridEducationCertificateObtained.DataPropertyName = "CertificateObtained";
            this.gridEducationCertificateObtained.FillWeight = 1.5F;
            this.gridEducationCertificateObtained.HeaderText = "Certificate Obtained";
            this.gridEducationCertificateObtained.Name = "gridEducationCertificateObtained";
            // 
            // gridEducationFromMonth
            // 
            this.gridEducationFromMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridEducationFromMonth.FillWeight = 1F;
            this.gridEducationFromMonth.HeaderText = "From(Month)";
            this.gridEducationFromMonth.Name = "gridEducationFromMonth";
            this.gridEducationFromMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gridEducationFromYear
            // 
            this.gridEducationFromYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridEducationFromYear.FillWeight = 1F;
            this.gridEducationFromYear.HeaderText = "From(Year)";
            this.gridEducationFromYear.Name = "gridEducationFromYear";
            this.gridEducationFromYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gridEducationToMonth
            // 
            this.gridEducationToMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridEducationToMonth.FillWeight = 1F;
            this.gridEducationToMonth.HeaderText = "To(Month)";
            this.gridEducationToMonth.Name = "gridEducationToMonth";
            this.gridEducationToMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gridEducationToYear
            // 
            this.gridEducationToYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridEducationToYear.FillWeight = 1F;
            this.gridEducationToYear.HeaderText = "To(Year)";
            this.gridEducationToYear.Name = "gridEducationToYear";
            this.gridEducationToYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gridReferees);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(736, 131);
            this.tabPage3.TabIndex = 20;
            this.tabPage3.Text = "Referees";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gridReferees
            // 
            this.gridReferees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridReferees.BackgroundColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReferees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridReferees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReferees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridRefereesID,
            this.gridRefereesName,
            this.gridRefereesOccupation,
            this.gridRefereesCompany,
            this.gridRefereesTelno});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridReferees.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridReferees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReferees.GridColor = System.Drawing.Color.Gainsboro;
            this.gridReferees.Location = new System.Drawing.Point(3, 3);
            this.gridReferees.Name = "gridReferees";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReferees.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridReferees.RowHeadersWidth = 5;
            this.gridReferees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReferees.Size = new System.Drawing.Size(730, 125);
            this.gridReferees.TabIndex = 2;
            // 
            // gridRefereesID
            // 
            this.gridRefereesID.HeaderText = "ID";
            this.gridRefereesID.Name = "gridRefereesID";
            this.gridRefereesID.Visible = false;
            // 
            // gridRefereesName
            // 
            this.gridRefereesName.FillWeight = 1.5F;
            this.gridRefereesName.HeaderText = "Name*";
            this.gridRefereesName.Name = "gridRefereesName";
            // 
            // gridRefereesOccupation
            // 
            this.gridRefereesOccupation.FillWeight = 1F;
            this.gridRefereesOccupation.HeaderText = "Occupation*";
            this.gridRefereesOccupation.Name = "gridRefereesOccupation";
            // 
            // gridRefereesCompany
            // 
            this.gridRefereesCompany.FillWeight = 1F;
            this.gridRefereesCompany.HeaderText = "Company*";
            this.gridRefereesCompany.Name = "gridRefereesCompany";
            // 
            // gridRefereesTelno
            // 
            this.gridRefereesTelno.FillWeight = 1F;
            this.gridRefereesTelno.HeaderText = "TelNo*";
            this.gridRefereesTelno.Name = "gridRefereesTelno";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gridSkill);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(736, 131);
            this.tabPage4.TabIndex = 21;
            this.tabPage4.Text = "Skills";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gridSkill
            // 
            this.gridSkill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSkill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridSkillsID,
            this.gridSkills});
            this.gridSkill.Location = new System.Drawing.Point(2, 0);
            this.gridSkill.Name = "gridSkill";
            this.gridSkill.Size = new System.Drawing.Size(734, 128);
            this.gridSkill.TabIndex = 1;
            // 
            // gridSkillsID
            // 
            this.gridSkillsID.HeaderText = "ID";
            this.gridSkillsID.Name = "gridSkillsID";
            this.gridSkillsID.Visible = false;
            // 
            // gridSkills
            // 
            this.gridSkills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridSkills.HeaderText = "Skill";
            this.gridSkills.Name = "gridSkills";
            // 
            // txtNumber
            // 
            this.txtNumber.FillWeight = 1F;
            this.txtNumber.HeaderText = "TelNo*";
            this.txtNumber.Name = "txtNumber";
            // 
            // refereesCompany
            // 
            this.refereesCompany.FillWeight = 1F;
            this.refereesCompany.HeaderText = "Company*";
            this.refereesCompany.Name = "refereesCompany";
            // 
            // txtOccupation
            // 
            this.txtOccupation.FillWeight = 1F;
            this.txtOccupation.HeaderText = "Occupation*";
            this.txtOccupation.Name = "txtOccupation";
            // 
            // txtName
            // 
            this.txtName.FillWeight = 1.5F;
            this.txtName.HeaderText = "Name*";
            this.txtName.Name = "txtName";
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "ID";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.Visible = false;
            // 
            // qualificationsToYear
            // 
            this.qualificationsToYear.HeaderText = "To (Year)";
            this.qualificationsToYear.Name = "qualificationsToYear";
            this.qualificationsToYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsToYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.qualificationsToYear.Width = 82;
            // 
            // qualificationsToMonth
            // 
            this.qualificationsToMonth.HeaderText = "To (Month)";
            this.qualificationsToMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.qualificationsToMonth.Name = "qualificationsToMonth";
            this.qualificationsToMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsToMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // qualificationsFromYear
            // 
            this.qualificationsFromYear.HeaderText = "From (Year)";
            this.qualificationsFromYear.Name = "qualificationsFromYear";
            this.qualificationsFromYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsFromYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.qualificationsFromYear.Width = 90;
            // 
            // qualificationsFromMonth
            // 
            this.qualificationsFromMonth.HeaderText = "From (Month)";
            this.qualificationsFromMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.qualificationsFromMonth.Name = "qualificationsFromMonth";
            this.qualificationsFromMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsFromMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // qualificationsCertificateObtained
            // 
            this.qualificationsCertificateObtained.DataPropertyName = "CertificateObtained";
            this.qualificationsCertificateObtained.HeaderText = "Certificate Obtained";
            this.qualificationsCertificateObtained.Name = "qualificationsCertificateObtained";
            this.qualificationsCertificateObtained.Width = 150;
            // 
            // qualificationsNameOfInstitution
            // 
            this.qualificationsNameOfInstitution.DataPropertyName = "NameOfInstitution";
            this.qualificationsNameOfInstitution.HeaderText = "Name of Institution";
            this.qualificationsNameOfInstitution.Name = "qualificationsNameOfInstitution";
            this.qualificationsNameOfInstitution.Width = 200;
            // 
            // qualificationsID
            // 
            this.qualificationsID.HeaderText = "ID";
            this.qualificationsID.Name = "qualificationsID";
            this.qualificationsID.Visible = false;
            // 
            // experienceToYear
            // 
            this.experienceToYear.DataPropertyName = "To";
            this.experienceToYear.HeaderText = "To (Year)";
            this.experienceToYear.Name = "experienceToYear";
            this.experienceToYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.experienceToYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.experienceToYear.Width = 88;
            // 
            // experienceToMonth
            // 
            this.experienceToMonth.HeaderText = "To (Month)";
            this.experienceToMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.experienceToMonth.Name = "experienceToMonth";
            // 
            // experienceFromYear
            // 
            this.experienceFromYear.DataPropertyName = "From";
            this.experienceFromYear.HeaderText = "From (Year)";
            this.experienceFromYear.Name = "experienceFromYear";
            this.experienceFromYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.experienceFromYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.experienceFromYear.Width = 89;
            // 
            // experienceFromMonth
            // 
            this.experienceFromMonth.HeaderText = "From (Month)";
            this.experienceFromMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.experienceFromMonth.Name = "experienceFromMonth";
            // 
            // experienceJobTitle
            // 
            this.experienceJobTitle.DataPropertyName = "JobDescription";
            this.experienceJobTitle.HeaderText = "Job Title";
            this.experienceJobTitle.Name = "experienceJobTitle";
            this.experienceJobTitle.Width = 150;
            // 
            // experienceNameOfOrganisation
            // 
            this.experienceNameOfOrganisation.DataPropertyName = "NameOfOrganisation";
            this.experienceNameOfOrganisation.HeaderText = "Name of Organisation";
            this.experienceNameOfOrganisation.Name = "experienceNameOfOrganisation";
            this.experienceNameOfOrganisation.Width = 200;
            // 
            // experienceID
            // 
            this.experienceID.HeaderText = "ID";
            this.experienceID.Name = "experienceID";
            this.experienceID.Visible = false;
            // 
            // ApplicantMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(770, 485);
            this.Controls.Add(this.tabOtherDetails);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboVacancy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ApplicantMaintenance";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Applicant View";
            this.Load += new System.EventHandler(this.ApplicantMaintenance_Load);
            this.Click += new System.EventHandler(this.ApplicantMaintenance_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.tabOtherDetails.ResumeLayout(false);
            this.documentsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmploymentHistory)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEducationHistory)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReferees)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSkill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button btnRemove;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        public System.Windows.Forms.Button btnSave;
        private CalendarColumn calendarColumn1;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboVacancy;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridVacancyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridVacancy;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridContactAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEmailAddress;
        private CalendarColumn gridApplicationDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridShortList;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
        private System.Windows.Forms.TabControl tabOtherDetails;
        private System.Windows.Forms.TabPage documentsTabPage;
        private System.Windows.Forms.DataGridView gridDocuments;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn refereesCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOccupation;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsToYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsToMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsFromYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsFromMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualificationsCertificateObtained;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualificationsNameOfInstitution;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualificationsID;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceToYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceToMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceFromYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceFromMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceJobTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceNameOfOrganisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceID;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gridEmploymentHistory;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gridEducationHistory;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView gridReferees;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEmploymentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNameOfOrganization;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridJobTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFromMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFromYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridToMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridToYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEducationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEducationNameOfInstitution;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEducationCertificateObtained;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEducationFromMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEducationFromYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEducationToMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEducationToYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRefereesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRefereesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRefereesOccupation;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRefereesCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRefereesTelno;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView gridSkill;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSkillsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSkills;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private CalendarColumn gridDocumentsDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
    }
}