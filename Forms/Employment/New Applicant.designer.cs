namespace eMAS.All_UIs.Applicants
{
    partial class NewApplicant
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contactAddressTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.contactNoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.emailAddressTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vacancyComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.calendarColumn1 = new CalendarColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn2 = new CalendarColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabOtherDetails = new System.Windows.Forms.TabControl();
            this.documentsTabPage = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            this.gridDocuments = new System.Windows.Forms.DataGridView();
            this.gridDocumentsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDateCreated = new CalendarColumn();
            this.gridDocumentsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridDocumentsPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employmentTabPage = new System.Windows.Forms.TabPage();
            this.gridEmploymentHistory = new System.Windows.Forms.DataGridView();
            this.experienceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceNameOfOrganisation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceJobTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceFromMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceFromYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceToMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceToYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.educationHistoryTabPage = new System.Windows.Forms.TabPage();
            this.gridEducationHistory = new System.Windows.Forms.DataGridView();
            this.qualificationsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationsNameOfInstitution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationsCertificateObtained = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationsFromMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsFromYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsToMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsToYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.refereeTabPage = new System.Windows.Forms.TabPage();
            this.gridReferees = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOccupation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refereesCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skillsTabPage = new System.Windows.Forms.TabPage();
            this.gridSkill = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSkills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabOtherDetails.SuspendLayout();
            this.documentsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).BeginInit();
            this.employmentTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmploymentHistory)).BeginInit();
            this.educationHistoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEducationHistory)).BeginInit();
            this.refereeTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReferees)).BeginInit();
            this.skillsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSkill)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.contactAddressTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.contactNoTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.emailAddressTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.vacancyComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSurname);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtMiddleName);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Demographics:";
            // 
            // contactAddressTextBox
            // 
            this.contactAddressTextBox.BackColor = System.Drawing.Color.White;
            this.contactAddressTextBox.Location = new System.Drawing.Point(434, 109);
            this.contactAddressTextBox.Name = "contactAddressTextBox";
            this.contactAddressTextBox.Size = new System.Drawing.Size(150, 20);
            this.contactAddressTextBox.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(324, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Contact Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(324, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Application Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(434, 86);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // contactNoTextBox
            // 
            this.contactNoTextBox.BackColor = System.Drawing.Color.White;
            this.contactNoTextBox.Location = new System.Drawing.Point(434, 40);
            this.contactNoTextBox.Name = "contactNoTextBox";
            this.contactNoTextBox.Size = new System.Drawing.Size(150, 20);
            this.contactNoTextBox.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(324, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Contact No:";
            // 
            // emailAddressTextBox
            // 
            this.emailAddressTextBox.BackColor = System.Drawing.Color.White;
            this.emailAddressTextBox.Location = new System.Drawing.Point(434, 63);
            this.emailAddressTextBox.Name = "emailAddressTextBox";
            this.emailAddressTextBox.Size = new System.Drawing.Size(150, 20);
            this.emailAddressTextBox.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(324, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Email Address:";
            // 
            // vacancyComboBox
            // 
            this.vacancyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vacancyComboBox.FormattingEnabled = true;
            this.vacancyComboBox.Items.AddRange(new object[] {
            "Mr",
            "Mrs",
            "Ms",
            "Dr",
            "Prof"});
            this.vacancyComboBox.Location = new System.Drawing.Point(112, 106);
            this.vacancyComboBox.Name = "vacancyComboBox";
            this.vacancyComboBox.Size = new System.Drawing.Size(150, 21);
            this.vacancyComboBox.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(19, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Vacancy:";
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.Color.White;
            this.txtSurname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSurname.Location = new System.Drawing.Point(112, 37);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(150, 20);
            this.txtSurname.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(19, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Surname:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.Location = new System.Drawing.Point(112, 60);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 20);
            this.txtFirstName.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(19, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "First Name:";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMiddleName.Location = new System.Drawing.Point(112, 83);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(150, 20);
            this.txtMiddleName.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(19, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Middle Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 33);
            this.panel2.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "New Applicant";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 43);
            this.panel1.TabIndex = 21;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(447, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(60, 23);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(575, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(509, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(381, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "DateCreated";
            this.calendarColumn1.HeaderText = "Date Created";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.ReadOnly = true;
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // calendarColumn2
            // 
            this.calendarColumn2.DataPropertyName = "DateCreated";
            this.calendarColumn2.HeaderText = "Date Created";
            this.calendarColumn2.Name = "calendarColumn2";
            this.calendarColumn2.ReadOnly = true;
            this.calendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn2.HeaderText = "Date Created";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DocumentType";
            this.dataGridViewTextBoxColumn4.HeaderText = "Document Type";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Document Group";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Path";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 197;
            // 
            // tabOtherDetails
            // 
            this.tabOtherDetails.Controls.Add(this.documentsTabPage);
            this.tabOtherDetails.Controls.Add(this.employmentTabPage);
            this.tabOtherDetails.Controls.Add(this.educationHistoryTabPage);
            this.tabOtherDetails.Controls.Add(this.refereeTabPage);
            this.tabOtherDetails.Controls.Add(this.skillsTabPage);
            this.tabOtherDetails.Location = new System.Drawing.Point(7, 192);
            this.tabOtherDetails.Name = "tabOtherDetails";
            this.tabOtherDetails.SelectedIndex = 0;
            this.tabOtherDetails.Size = new System.Drawing.Size(624, 262);
            this.tabOtherDetails.TabIndex = 30;
            // 
            // documentsTabPage
            // 
            this.documentsTabPage.Controls.Add(this.button2);
            this.documentsTabPage.Controls.Add(this.viewButton);
            this.documentsTabPage.Controls.Add(this.gridDocuments);
            this.documentsTabPage.Location = new System.Drawing.Point(4, 22);
            this.documentsTabPage.Name = "documentsTabPage";
            this.documentsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.documentsTabPage.Size = new System.Drawing.Size(616, 236);
            this.documentsTabPage.TabIndex = 17;
            this.documentsTabPage.Text = "Documents";
            this.documentsTabPage.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(455, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(536, 210);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(75, 23);
            this.viewButton.TabIndex = 6;
            this.viewButton.Text = "Preview";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // gridDocuments
            // 
            this.gridDocuments.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.gridDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDocuments.BackgroundColor = System.Drawing.Color.SlateGray;
            this.gridDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridDocumentsID,
            this.gridDocumentsDateCreated,
            this.gridDocumentsDescription,
            this.gridDocumentsDocumentType,
            this.gridDocumentsDocumentGroup,
            this.gridDocumentsPath,
            this.gridDocumentsDocumentContent});
            this.gridDocuments.GridColor = System.Drawing.SystemColors.Control;
            this.gridDocuments.Location = new System.Drawing.Point(8, 7);
            this.gridDocuments.Name = "gridDocuments";
            this.gridDocuments.RowHeadersWidth = 23;
            this.gridDocuments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDocuments.Size = new System.Drawing.Size(604, 199);
            this.gridDocuments.TabIndex = 5;
            // 
            // gridDocumentsID
            // 
            this.gridDocumentsID.HeaderText = "ID";
            this.gridDocumentsID.Name = "gridDocumentsID";
            this.gridDocumentsID.Visible = false;
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
            this.gridDocumentsDescription.DataPropertyName = "Description";
            this.gridDocumentsDescription.HeaderText = "Description";
            this.gridDocumentsDescription.Name = "gridDocumentsDescription";
            this.gridDocumentsDescription.Width = 250;
            // 
            // gridDocumentsDocumentType
            // 
            this.gridDocumentsDocumentType.DataPropertyName = "DocumentType";
            this.gridDocumentsDocumentType.HeaderText = "Document Type";
            this.gridDocumentsDocumentType.Name = "gridDocumentsDocumentType";
            this.gridDocumentsDocumentType.ReadOnly = true;
            this.gridDocumentsDocumentType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDocumentsDocumentType.Visible = false;
            this.gridDocumentsDocumentType.Width = 150;
            // 
            // gridDocumentsDocumentGroup
            // 
            this.gridDocumentsDocumentGroup.HeaderText = "Document Group";
            this.gridDocumentsDocumentGroup.Name = "gridDocumentsDocumentGroup";
            this.gridDocumentsDocumentGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDocumentsDocumentGroup.Width = 160;
            // 
            // gridDocumentsPath
            // 
            this.gridDocumentsPath.HeaderText = "Path";
            this.gridDocumentsPath.Name = "gridDocumentsPath";
            this.gridDocumentsPath.ReadOnly = true;
            this.gridDocumentsPath.Width = 197;
            // 
            // gridDocumentsDocumentContent
            // 
            this.gridDocumentsDocumentContent.HeaderText = "DocumentContent";
            this.gridDocumentsDocumentContent.Name = "gridDocumentsDocumentContent";
            this.gridDocumentsDocumentContent.Visible = false;
            // 
            // employmentTabPage
            // 
            this.employmentTabPage.Controls.Add(this.gridEmploymentHistory);
            this.employmentTabPage.Location = new System.Drawing.Point(4, 22);
            this.employmentTabPage.Name = "employmentTabPage";
            this.employmentTabPage.Size = new System.Drawing.Size(616, 236);
            this.employmentTabPage.TabIndex = 8;
            this.employmentTabPage.Text = "Employment History";
            this.employmentTabPage.UseVisualStyleBackColor = true;
            // 
            // gridEmploymentHistory
            // 
            this.gridEmploymentHistory.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridEmploymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmploymentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.experienceID,
            this.experienceNameOfOrganisation,
            this.experienceJobTitle,
            this.experienceFromMonth,
            this.experienceFromYear,
            this.experienceToMonth,
            this.experienceToYear});
            this.gridEmploymentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmploymentHistory.GridColor = System.Drawing.Color.Gainsboro;
            this.gridEmploymentHistory.Location = new System.Drawing.Point(0, 0);
            this.gridEmploymentHistory.Name = "gridEmploymentHistory";
            this.gridEmploymentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmploymentHistory.Size = new System.Drawing.Size(616, 236);
            this.gridEmploymentHistory.TabIndex = 1;
            this.gridEmploymentHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEmploymentHistory_CellClick);
            // 
            // experienceID
            // 
            this.experienceID.HeaderText = "ID";
            this.experienceID.Name = "experienceID";
            this.experienceID.Visible = false;
            // 
            // experienceNameOfOrganisation
            // 
            this.experienceNameOfOrganisation.DataPropertyName = "NameOfOrganisation";
            this.experienceNameOfOrganisation.HeaderText = "Name of Organisation";
            this.experienceNameOfOrganisation.Name = "experienceNameOfOrganisation";
            this.experienceNameOfOrganisation.Width = 200;
            // 
            // experienceJobTitle
            // 
            this.experienceJobTitle.DataPropertyName = "JobDescription";
            this.experienceJobTitle.HeaderText = "Job Title";
            this.experienceJobTitle.Name = "experienceJobTitle";
            this.experienceJobTitle.Width = 150;
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
            // experienceFromYear
            // 
            this.experienceFromYear.DataPropertyName = "From";
            this.experienceFromYear.HeaderText = "From (Year)";
            this.experienceFromYear.Name = "experienceFromYear";
            this.experienceFromYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.experienceFromYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.experienceFromYear.Width = 89;
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
            // experienceToYear
            // 
            this.experienceToYear.DataPropertyName = "To";
            this.experienceToYear.HeaderText = "To (Year)";
            this.experienceToYear.Name = "experienceToYear";
            this.experienceToYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.experienceToYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.experienceToYear.Width = 88;
            // 
            // educationHistoryTabPage
            // 
            this.educationHistoryTabPage.BackColor = System.Drawing.Color.Lavender;
            this.educationHistoryTabPage.Controls.Add(this.gridEducationHistory);
            this.educationHistoryTabPage.Location = new System.Drawing.Point(4, 22);
            this.educationHistoryTabPage.Name = "educationHistoryTabPage";
            this.educationHistoryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.educationHistoryTabPage.Size = new System.Drawing.Size(616, 236);
            this.educationHistoryTabPage.TabIndex = 14;
            this.educationHistoryTabPage.Text = "Education History";
            this.educationHistoryTabPage.UseVisualStyleBackColor = true;
            // 
            // gridEducationHistory
            // 
            this.gridEducationHistory.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridEducationHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEducationHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qualificationsID,
            this.qualificationsNameOfInstitution,
            this.qualificationsCertificateObtained,
            this.qualificationsFromMonth,
            this.qualificationsFromYear,
            this.qualificationsToMonth,
            this.qualificationsToYear});
            this.gridEducationHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEducationHistory.GridColor = System.Drawing.Color.Gainsboro;
            this.gridEducationHistory.Location = new System.Drawing.Point(3, 3);
            this.gridEducationHistory.Name = "gridEducationHistory";
            this.gridEducationHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEducationHistory.Size = new System.Drawing.Size(610, 230);
            this.gridEducationHistory.TabIndex = 1;
            // 
            // qualificationsID
            // 
            this.qualificationsID.HeaderText = "ID";
            this.qualificationsID.Name = "qualificationsID";
            this.qualificationsID.Visible = false;
            // 
            // qualificationsNameOfInstitution
            // 
            this.qualificationsNameOfInstitution.DataPropertyName = "NameOfInstitution";
            this.qualificationsNameOfInstitution.HeaderText = "Name of Institution";
            this.qualificationsNameOfInstitution.Name = "qualificationsNameOfInstitution";
            this.qualificationsNameOfInstitution.Width = 200;
            // 
            // qualificationsCertificateObtained
            // 
            this.qualificationsCertificateObtained.DataPropertyName = "CertificateObtained";
            this.qualificationsCertificateObtained.HeaderText = "Certificate Obtained";
            this.qualificationsCertificateObtained.Name = "qualificationsCertificateObtained";
            this.qualificationsCertificateObtained.Width = 150;
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
            // qualificationsFromYear
            // 
            this.qualificationsFromYear.HeaderText = "From (Year)";
            this.qualificationsFromYear.Name = "qualificationsFromYear";
            this.qualificationsFromYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsFromYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.qualificationsFromYear.Width = 90;
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
            // qualificationsToYear
            // 
            this.qualificationsToYear.HeaderText = "To (Year)";
            this.qualificationsToYear.Name = "qualificationsToYear";
            this.qualificationsToYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsToYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.qualificationsToYear.Width = 82;
            // 
            // refereeTabPage
            // 
            this.refereeTabPage.BackColor = System.Drawing.Color.Lavender;
            this.refereeTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.refereeTabPage.Controls.Add(this.gridReferees);
            this.refereeTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refereeTabPage.Location = new System.Drawing.Point(4, 22);
            this.refereeTabPage.Name = "refereeTabPage";
            this.refereeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.refereeTabPage.Size = new System.Drawing.Size(616, 236);
            this.refereeTabPage.TabIndex = 16;
            this.refereeTabPage.Text = "Referees";
            this.refereeTabPage.UseVisualStyleBackColor = true;
            // 
            // gridReferees
            // 
            this.gridReferees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridReferees.BackgroundColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReferees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridReferees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReferees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.txtName,
            this.txtOccupation,
            this.refereesCompany,
            this.txtNumber});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridReferees.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridReferees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReferees.GridColor = System.Drawing.Color.Gainsboro;
            this.gridReferees.Location = new System.Drawing.Point(3, 3);
            this.gridReferees.Name = "gridReferees";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReferees.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridReferees.RowHeadersWidth = 5;
            this.gridReferees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReferees.Size = new System.Drawing.Size(608, 228);
            this.gridReferees.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "ID";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // txtName
            // 
            this.txtName.FillWeight = 1.5F;
            this.txtName.HeaderText = "Name*";
            this.txtName.Name = "txtName";
            // 
            // txtOccupation
            // 
            this.txtOccupation.FillWeight = 1F;
            this.txtOccupation.HeaderText = "Occupation*";
            this.txtOccupation.Name = "txtOccupation";
            // 
            // refereesCompany
            // 
            this.refereesCompany.FillWeight = 1F;
            this.refereesCompany.HeaderText = "Company*";
            this.refereesCompany.Name = "refereesCompany";
            // 
            // txtNumber
            // 
            this.txtNumber.FillWeight = 1F;
            this.txtNumber.HeaderText = "TelNo*";
            this.txtNumber.Name = "txtNumber";
            // 
            // skillsTabPage
            // 
            this.skillsTabPage.Controls.Add(this.gridSkill);
            this.skillsTabPage.Location = new System.Drawing.Point(4, 22);
            this.skillsTabPage.Name = "skillsTabPage";
            this.skillsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.skillsTabPage.Size = new System.Drawing.Size(616, 236);
            this.skillsTabPage.TabIndex = 18;
            this.skillsTabPage.Text = "Skills";
            this.skillsTabPage.UseVisualStyleBackColor = true;
            // 
            // gridSkill
            // 
            this.gridSkill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSkill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridSkills});
            this.gridSkill.Location = new System.Drawing.Point(1, 0);
            this.gridSkill.Name = "gridSkill";
            this.gridSkill.Size = new System.Drawing.Size(612, 236);
            this.gridSkill.TabIndex = 0;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.Visible = false;
            // 
            // gridSkills
            // 
            this.gridSkills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridSkills.HeaderText = "Skill";
            this.gridSkills.Name = "gridSkills";
            // 
            // NewApplicant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(643, 496);
            this.Controls.Add(this.tabOtherDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "NewApplicant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Applicant";
            this.Load += new System.EventHandler(this.NewApplicant_Load);
            this.Click += new System.EventHandler(this.New_Applicant_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabOtherDetails.ResumeLayout(false);
            this.documentsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).EndInit();
            this.employmentTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmploymentHistory)).EndInit();
            this.educationHistoryTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEducationHistory)).EndInit();
            this.refereeTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReferees)).EndInit();
            this.skillsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSkill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox vacancyComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox contactNoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailAddressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contactAddressTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private CalendarColumn calendarColumn1;
        private CalendarColumn calendarColumn2;
        private System.Windows.Forms.TabControl tabOtherDetails;
        private System.Windows.Forms.TabPage documentsTabPage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.DataGridView gridDocuments;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsID;
        private CalendarColumn gridDocumentsDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentType;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridDocumentsDocumentGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentContent;
        private System.Windows.Forms.TabPage employmentTabPage;
        private System.Windows.Forms.DataGridView gridEmploymentHistory;
        private System.Windows.Forms.TabPage refereeTabPage;
        private System.Windows.Forms.DataGridView gridReferees;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceNameOfOrganisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceJobTitle;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceFromMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceFromYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceToMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceToYear;
        private System.Windows.Forms.TabPage educationHistoryTabPage;
        private System.Windows.Forms.DataGridView gridEducationHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualificationsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualificationsNameOfInstitution;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualificationsCertificateObtained;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsFromMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsFromYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsToMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsToYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOccupation;
        private System.Windows.Forms.DataGridViewTextBoxColumn refereesCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNumber;
        private System.Windows.Forms.TabPage skillsTabPage;
        private System.Windows.Forms.DataGridView gridSkill;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSkills;
    }
}