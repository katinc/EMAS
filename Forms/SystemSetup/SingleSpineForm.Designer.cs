namespace eMAS.Forms.SystemSetup
{
    partial class SingleSpineForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStep = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridOtherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridBasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMaritalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGradeCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBasicSalary);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboGrade);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboGradeCategory);
            this.groupBox1.Controls.Add(this.lblLevel);
            this.groupBox1.Controls.Add(this.cboLevel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboStep);
            this.groupBox1.Location = new System.Drawing.Point(3, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 109);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterior";
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Location = new System.Drawing.Point(94, 69);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(136, 20);
            this.txtBasicSalary.TabIndex = 86;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(236, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 34);
            this.btnSave.TabIndex = 85;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Basic Salary:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(520, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 50);
            this.btnSearch.TabIndex = 81;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "Grade:";
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(94, 42);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(186, 21);
            this.cboGrade.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Grade Category:";
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(94, 15);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(186, 21);
            this.cboGradeCategory.TabIndex = 75;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(291, 44);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(36, 13);
            this.lblLevel.TabIndex = 74;
            this.lblLevel.Text = "Level:";
            // 
            // cboLevel
            // 
            this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Location = new System.Drawing.Point(333, 39);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(180, 21);
            this.cboLevel.TabIndex = 73;
            this.cboLevel.DropDown += new System.EventHandler(this.cboLevel_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Step:";
            // 
            // cboStep
            // 
            this.cboStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStep.FormattingEnabled = true;
            this.cboStep.Location = new System.Drawing.Point(334, 14);
            this.cboStep.Name = "cboStep";
            this.cboStep.Size = new System.Drawing.Size(180, 21);
            this.cboStep.TabIndex = 71;
            this.cboStep.DropDown += new System.EventHandler(this.cboStep_DropDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 29);
            this.panel1.TabIndex = 71;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(11, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Single Spine Structure Form";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.Location = new System.Drawing.Point(3, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 317);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee Records";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridSelect,
            this.gridStaffNo,
            this.gridTitle,
            this.gridFirstName,
            this.gridOtherName,
            this.gridSurname,
            this.gridBasicSalary,
            this.gridGender,
            this.gridMaritalStatus,
            this.gridDepartment,
            this.gridUnit,
            this.gridGradeCategory,
            this.gridGrade,
            this.gridUserID});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 16);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 5;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(666, 298);
            this.grid.TabIndex = 0;
            // 
            // gridSelect
            // 
            this.gridSelect.HeaderText = "";
            this.gridSelect.Name = "gridSelect";
            this.gridSelect.Width = 50;
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffNo";
            this.gridStaffNo.HeaderText = "Staff ID ";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            this.gridStaffNo.Width = 80;
            // 
            // gridTitle
            // 
            this.gridTitle.HeaderText = "Title";
            this.gridTitle.Name = "gridTitle";
            this.gridTitle.ReadOnly = true;
            this.gridTitle.Width = 70;
            // 
            // gridFirstName
            // 
            this.gridFirstName.DataPropertyName = "FirstName";
            this.gridFirstName.HeaderText = "First Name";
            this.gridFirstName.Name = "gridFirstName";
            this.gridFirstName.ReadOnly = true;
            this.gridFirstName.Width = 124;
            // 
            // gridOtherName
            // 
            this.gridOtherName.DataPropertyName = "Department";
            this.gridOtherName.HeaderText = "Middle Name";
            this.gridOtherName.Name = "gridOtherName";
            this.gridOtherName.ReadOnly = true;
            this.gridOtherName.Width = 123;
            // 
            // gridSurname
            // 
            this.gridSurname.DataPropertyName = "Surname";
            this.gridSurname.HeaderText = "Surname";
            this.gridSurname.Name = "gridSurname";
            this.gridSurname.ReadOnly = true;
            this.gridSurname.Width = 123;
            // 
            // gridBasicSalary
            // 
            this.gridBasicSalary.HeaderText = "Basic Salary";
            this.gridBasicSalary.Name = "gridBasicSalary";
            // 
            // gridGender
            // 
            this.gridGender.HeaderText = "Gender";
            this.gridGender.Name = "gridGender";
            this.gridGender.ReadOnly = true;
            // 
            // gridMaritalStatus
            // 
            this.gridMaritalStatus.HeaderText = "MaritalStatus";
            this.gridMaritalStatus.Name = "gridMaritalStatus";
            this.gridMaritalStatus.ReadOnly = true;
            // 
            // gridDepartment
            // 
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.ReadOnly = true;
            this.gridDepartment.Width = 150;
            // 
            // gridUnit
            // 
            this.gridUnit.HeaderText = "Unit";
            this.gridUnit.Name = "gridUnit";
            this.gridUnit.ReadOnly = true;
            // 
            // gridGradeCategory
            // 
            this.gridGradeCategory.HeaderText = "GradeCategory";
            this.gridGradeCategory.Name = "gridGradeCategory";
            this.gridGradeCategory.ReadOnly = true;
            // 
            // gridGrade
            // 
            this.gridGrade.HeaderText = "Grade";
            this.gridGrade.Name = "gridGrade";
            this.gridGrade.ReadOnly = true;
            // 
            // gridUserID
            // 
            this.gridUserID.HeaderText = "UserID";
            this.gridUserID.Name = "gridUserID";
            this.gridUserID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnSelectAll);
            this.panel2.Controls.Add(this.btnClearSelection);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(-7, 474);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 34);
            this.panel2.TabIndex = 73;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(543, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(303, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(384, 8);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 28;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(465, 8);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(72, 23);
            this.btnClearSelection.TabIndex = 27;
            this.btnClearSelection.Text = "Clear";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(624, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SingleSpineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 508);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "SingleSpineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Single Spine Structure Form";
            this.Load += new System.EventHandler(this.SingleSpineForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStep;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridOtherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridBasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMaritalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGradeCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
    }
}