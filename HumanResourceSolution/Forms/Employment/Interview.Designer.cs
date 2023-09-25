namespace eMAS.Forms.Employment
{
    partial class Interview
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
            dalHelper.CloseConnection();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.vacanyComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnJobDescription = new System.Windows.Forms.Button();
            this.requirementsGrid = new System.Windows.Forms.DataGridView();
            this.requirementsGridRequirement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requirementsGridRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionsGrid = new System.Windows.Forms.DataGridView();
            this.descriptionsGridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionsGridVacancyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionsGridDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.commentsGrid = new System.Windows.Forms.DataGridView();
            this.gridInterviewID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.totalScoreTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.gridDocuments = new System.Windows.Forms.DataGridView();
            this.gridDocumentsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDateCreated = new CalendarColumn();
            this.gridDocumentsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new CalendarColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAssessment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionsGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commentsGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // vacanyComboBox
            // 
            this.vacanyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vacanyComboBox.FormattingEnabled = true;
            this.vacanyComboBox.Location = new System.Drawing.Point(84, 44);
            this.vacanyComboBox.Name = "vacanyComboBox";
            this.vacanyComboBox.Size = new System.Drawing.Size(195, 21);
            this.vacanyComboBox.TabIndex = 0;
            this.vacanyComboBox.SelectedIndexChanged += new System.EventHandler(this.vacanyComboBox_SelectedIndexChanged);
            this.vacanyComboBox.DropDown += new System.EventHandler(this.vacanyComboBox_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vacancy:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnJobDescription);
            this.groupBox1.Controls.Add(this.requirementsGrid);
            this.groupBox1.Controls.Add(this.descriptionsGrid);
            this.groupBox1.Location = new System.Drawing.Point(10, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assesment";
            // 
            // btnJobDescription
            // 
            this.btnJobDescription.Location = new System.Drawing.Point(547, 173);
            this.btnJobDescription.Name = "btnJobDescription";
            this.btnJobDescription.Size = new System.Drawing.Size(113, 23);
            this.btnJobDescription.TabIndex = 4;
            this.btnJobDescription.Text = "Job Description";
            this.btnJobDescription.UseVisualStyleBackColor = true;
            this.btnJobDescription.Click += new System.EventHandler(this.btnJobDescription_Click);
            // 
            // requirementsGrid
            // 
            this.requirementsGrid.AllowUserToAddRows = false;
            this.requirementsGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            this.requirementsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.requirementsGrid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.requirementsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requirementsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requirementsGridRequirement,
            this.requirementsGridRating});
            this.requirementsGrid.Location = new System.Drawing.Point(3, 17);
            this.requirementsGrid.Name = "requirementsGrid";
            this.requirementsGrid.Size = new System.Drawing.Size(665, 152);
            this.requirementsGrid.TabIndex = 0;
            this.requirementsGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.requirementsGrid_EditingControlShowing);
            // 
            // requirementsGridRequirement
            // 
            this.requirementsGridRequirement.HeaderText = "Job Requirement";
            this.requirementsGridRequirement.Name = "requirementsGridRequirement";
            this.requirementsGridRequirement.Width = 500;
            // 
            // requirementsGridRating
            // 
            this.requirementsGridRating.HeaderText = "Rating (%)";
            this.requirementsGridRating.Name = "requirementsGridRating";
            // 
            // descriptionsGrid
            // 
            this.descriptionsGrid.AllowUserToAddRows = false;
            this.descriptionsGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            this.descriptionsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.descriptionsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.descriptionsGrid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.descriptionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.descriptionsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionsGridID,
            this.descriptionsGridVacancyID,
            this.descriptionsGridDescription});
            this.descriptionsGrid.Location = new System.Drawing.Point(3, 16);
            this.descriptionsGrid.Name = "descriptionsGrid";
            this.descriptionsGrid.ReadOnly = true;
            this.descriptionsGrid.Size = new System.Drawing.Size(665, 153);
            this.descriptionsGrid.TabIndex = 5;
            // 
            // descriptionsGridID
            // 
            this.descriptionsGridID.Frozen = true;
            this.descriptionsGridID.HeaderText = "ID";
            this.descriptionsGridID.Name = "descriptionsGridID";
            this.descriptionsGridID.ReadOnly = true;
            this.descriptionsGridID.Visible = false;
            // 
            // descriptionsGridVacancyID
            // 
            this.descriptionsGridVacancyID.HeaderText = "VacancyID";
            this.descriptionsGridVacancyID.Name = "descriptionsGridVacancyID";
            this.descriptionsGridVacancyID.ReadOnly = true;
            this.descriptionsGridVacancyID.Visible = false;
            // 
            // descriptionsGridDescription
            // 
            this.descriptionsGridDescription.HeaderText = "Job Description";
            this.descriptionsGridDescription.Name = "descriptionsGridDescription";
            this.descriptionsGridDescription.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.commentsGrid);
            this.groupBox2.Location = new System.Drawing.Point(8, 413);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 124);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comments";
            // 
            // commentsGrid
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            this.commentsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.commentsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.commentsGrid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.commentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridInterviewID,
            this.gridComments});
            this.commentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentsGrid.Location = new System.Drawing.Point(3, 16);
            this.commentsGrid.Name = "commentsGrid";
            this.commentsGrid.Size = new System.Drawing.Size(487, 105);
            this.commentsGrid.TabIndex = 0;
            // 
            // gridInterviewID
            // 
            this.gridInterviewID.HeaderText = "InterviewID";
            this.gridInterviewID.Name = "gridInterviewID";
            this.gridInterviewID.Visible = false;
            // 
            // gridComments
            // 
            this.gridComments.HeaderText = "Comments";
            this.gridComments.Name = "gridComments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Score";
            // 
            // totalScoreTextBox
            // 
            this.totalScoreTextBox.BackColor = System.Drawing.Color.White;
            this.totalScoreTextBox.Location = new System.Drawing.Point(62, 28);
            this.totalScoreTextBox.Name = "totalScoreTextBox";
            this.totalScoreTextBox.ReadOnly = true;
            this.totalScoreTextBox.Size = new System.Drawing.Size(102, 20);
            this.totalScoreTextBox.TabIndex = 5;
            this.totalScoreTextBox.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.statusComboBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.totalScoreTextBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(505, 413);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 118);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results";
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Rejected",
            "Accepted",
            "Review"});
            this.statusComboBox.Location = new System.Drawing.Point(62, 54);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(102, 21);
            this.statusComboBox.TabIndex = 7;
            this.statusComboBox.DropDown += new System.EventHandler(this.statusComboBox_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status";
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
            this.panel1.Location = new System.Drawing.Point(-4, 544);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 40);
            this.panel1.TabIndex = 24;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(570, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(60, 23);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(636, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(505, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(439, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(-4, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(706, 33);
            this.panel2.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "New Interview";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Name:";
            // 
            // nameComboBox
            // 
            this.nameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(333, 45);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(219, 21);
            this.nameComboBox.TabIndex = 26;
            this.nameComboBox.SelectedIndexChanged += new System.EventHandler(this.nameComboBox_SelectedIndexChanged);
            this.nameComboBox.TextChanged += new System.EventHandler(this.nameComboBox_TextChanged);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btnPreview);
            this.groupBox19.Controls.Add(this.gridDocuments);
            this.groupBox19.Location = new System.Drawing.Point(14, 68);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(668, 150);
            this.groupBox19.TabIndex = 28;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Documents";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(580, 123);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // gridDocuments
            // 
            this.gridDocuments.AllowUserToAddRows = false;
            this.gridDocuments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            this.gridDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
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
            this.gridDocuments.Location = new System.Drawing.Point(1, 16);
            this.gridDocuments.Name = "gridDocuments";
            this.gridDocuments.ReadOnly = true;
            this.gridDocuments.RowHeadersWidth = 23;
            this.gridDocuments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDocuments.Size = new System.Drawing.Size(654, 104);
            this.gridDocuments.TabIndex = 2;
            this.gridDocuments.CurrentCellDirtyStateChanged += new System.EventHandler(this.requirementsGrid_CurrentCellDirtyStateChanged);
            // 
            // gridDocumentsID
            // 
            this.gridDocumentsID.HeaderText = "ID";
            this.gridDocumentsID.Name = "gridDocumentsID";
            this.gridDocumentsID.ReadOnly = true;
            this.gridDocumentsID.Visible = false;
            this.gridDocumentsID.Width = 50;
            // 
            // gridDocumentsDateCreated
            // 
            this.gridDocumentsDateCreated.DataPropertyName = "DateCreated";
            this.gridDocumentsDateCreated.HeaderText = "Date Created";
            this.gridDocumentsDateCreated.Name = "gridDocumentsDateCreated";
            this.gridDocumentsDateCreated.ReadOnly = true;
            this.gridDocumentsDateCreated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDocumentsDateCreated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridDocumentsDateCreated.Width = 80;
            // 
            // gridDocumentsDescription
            // 
            this.gridDocumentsDescription.DataPropertyName = "Description";
            this.gridDocumentsDescription.HeaderText = "Description";
            this.gridDocumentsDescription.Name = "gridDocumentsDescription";
            this.gridDocumentsDescription.ReadOnly = true;
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
            // 
            // gridDocumentsDocumentGroup
            // 
            this.gridDocumentsDocumentGroup.HeaderText = "Document Group";
            this.gridDocumentsDocumentGroup.Name = "gridDocumentsDocumentGroup";
            this.gridDocumentsDocumentGroup.ReadOnly = true;
            this.gridDocumentsDocumentGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDocumentsDocumentGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.gridDocumentsDocumentContent.ReadOnly = true;
            this.gridDocumentsDocumentContent.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Questions";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 350;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Score";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 348;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "No.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "DateCreated";
            this.calendarColumn1.HeaderText = "Date Created";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn5.HeaderText = "Assessment";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 300;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DocumentType";
            this.dataGridViewTextBoxColumn6.HeaderText = "Score";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Document Group";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 160;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Path";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 197;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "DocumentContent";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // gridAssessment
            // 
            this.gridAssessment.HeaderText = "Assessment";
            this.gridAssessment.Name = "gridAssessment";
            this.gridAssessment.Width = 300;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Interview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(704, 577);
            this.Controls.Add(this.groupBox19);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nameComboBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vacanyComboBox);
            this.Name = "Interview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interview";
            this.Load += new System.EventHandler(this.Interview_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requirementsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionsGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commentsGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox vacanyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView requirementsGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView commentsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAssessment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalScoreTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DataGridView gridDocuments;
        private CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Button btnJobDescription;
        private System.Windows.Forms.DataGridView descriptionsGrid;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirementsGridRequirement;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirementsGridRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionsGridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionsGridVacancyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionsGridDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsID;
        private CalendarColumn gridDocumentsDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridInterviewID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridComments;
    }
}