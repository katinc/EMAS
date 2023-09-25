namespace eMAS.Forms.Reports
{
    partial class LeaveResumptionReportSelect
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
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLeaveType = new System.Windows.Forms.Label();
            this.cboLeaveType = new System.Windows.Forms.ComboBox();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblGradeCategory = new System.Windows.Forms.Label();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.txtStaffNo = new System.Windows.Forms.TextBox();
            this.staffNoLabel = new System.Windows.Forms.Label();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStaffName
            // 
            this.txtStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffName.Location = new System.Drawing.Point(63, 74);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(243, 20);
            this.txtStaffName.TabIndex = 1;
            this.txtStaffName.Visible = false;
            this.txtStaffName.TextChanged += new System.EventHandler(this.txtStaffName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "From:";
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Checked = false;
            this.datePickerFrom.CustomFormat = " dd/MM/yyyy";
            this.datePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerFrom.Location = new System.Drawing.Point(62, 8);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.ShowCheckBox = true;
            this.datePickerFrom.Size = new System.Drawing.Size(146, 20);
            this.datePickerFrom.TabIndex = 35;
            this.datePickerFrom.Value = new System.DateTime(2015, 5, 20, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(373, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "To:";
            // 
            // datePickerTo
            // 
            this.datePickerTo.Checked = false;
            this.datePickerTo.CustomFormat = " dd/MM/yyyy";
            this.datePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerTo.Location = new System.Drawing.Point(400, 6);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.ShowCheckBox = true;
            this.datePickerTo.Size = new System.Drawing.Size(148, 20);
            this.datePickerTo.TabIndex = 33;
            this.datePickerTo.Value = new System.DateTime(2015, 5, 20, 0, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.txtStaffName);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.datePickerFrom);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.datePickerTo);
            this.panel2.Controls.Add(this.lblLeaveType);
            this.panel2.Controls.Add(this.cboLeaveType);
            this.panel2.Controls.Add(this.cboGrade);
            this.panel2.Controls.Add(this.lblGrade);
            this.panel2.Controls.Add(this.lblGradeCategory);
            this.panel2.Controls.Add(this.cboGradeCategory);
            this.panel2.Controls.Add(this.cboUnit);
            this.panel2.Controls.Add(this.lblUnit);
            this.panel2.Controls.Add(this.lblDepartment);
            this.panel2.Controls.Add(this.cboDepartment);
            this.panel2.Controls.Add(this.cboZone);
            this.panel2.Controls.Add(this.lblZone);
            this.panel2.Controls.Add(this.txtStaffNo);
            this.panel2.Controls.Add(this.staffNoLabel);
            this.panel2.Controls.Add(this.cmbOption);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.searchGrid);
            this.panel2.Location = new System.Drawing.Point(3, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 184);
            this.panel2.TabIndex = 29;
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.AutoSize = true;
            this.lblLeaveType.BackColor = System.Drawing.Color.Transparent;
            this.lblLeaveType.Location = new System.Drawing.Point(327, 159);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(70, 13);
            this.lblLeaveType.TabIndex = 32;
            this.lblLeaveType.Text = "Leave Type :";
            this.lblLeaveType.Visible = false;
            // 
            // cboLeaveType
            // 
            this.cboLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaveType.FormattingEnabled = true;
            this.cboLeaveType.Location = new System.Drawing.Point(400, 155);
            this.cboLeaveType.Name = "cboLeaveType";
            this.cboLeaveType.Size = new System.Drawing.Size(148, 21);
            this.cboLeaveType.TabIndex = 31;
            this.cboLeaveType.Visible = false;
            this.cboLeaveType.DropDown += new System.EventHandler(this.cboLeaveType_DropDown);
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(400, 130);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(148, 21);
            this.cboGrade.TabIndex = 30;
            this.cboGrade.Visible = false;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblGrade.Location = new System.Drawing.Point(355, 134);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(42, 13);
            this.lblGrade.TabIndex = 29;
            this.lblGrade.Text = "Grade :";
            this.lblGrade.Visible = false;
            // 
            // lblGradeCategory
            // 
            this.lblGradeCategory.AutoSize = true;
            this.lblGradeCategory.Location = new System.Drawing.Point(342, 111);
            this.lblGradeCategory.Name = "lblGradeCategory";
            this.lblGradeCategory.Size = new System.Drawing.Size(55, 13);
            this.lblGradeCategory.TabIndex = 28;
            this.lblGradeCategory.Text = "Category :";
            this.lblGradeCategory.Visible = false;
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(400, 106);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(148, 21);
            this.cboGradeCategory.TabIndex = 27;
            this.cboGradeCategory.Visible = false;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(400, 55);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(148, 21);
            this.cboUnit.TabIndex = 26;
            this.cboUnit.Visible = false;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.Location = new System.Drawing.Point(364, 59);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(32, 13);
            this.lblUnit.TabIndex = 25;
            this.lblUnit.Text = "Unit :";
            this.lblUnit.Visible = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(329, 36);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(68, 13);
            this.lblDepartment.TabIndex = 24;
            this.lblDepartment.Text = "Department :";
            this.lblDepartment.Visible = false;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(400, 31);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(148, 21);
            this.cboDepartment.TabIndex = 22;
            this.cboDepartment.Visible = false;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Location = new System.Drawing.Point(400, 81);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(148, 21);
            this.cboZone.TabIndex = 23;
            this.cboZone.Visible = false;
            this.cboZone.DropDown += new System.EventHandler(this.cboZone_DropDown);
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.BackColor = System.Drawing.Color.Transparent;
            this.lblZone.Location = new System.Drawing.Point(358, 86);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(38, 13);
            this.lblZone.TabIndex = 21;
            this.lblZone.Text = "Zone :";
            this.lblZone.Visible = false;
            // 
            // txtStaffNo
            // 
            this.txtStaffNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffNo.Location = new System.Drawing.Point(63, 53);
            this.txtStaffNo.Name = "txtStaffNo";
            this.txtStaffNo.Size = new System.Drawing.Size(97, 20);
            this.txtStaffNo.TabIndex = 1;
            this.txtStaffNo.Visible = false;
            this.txtStaffNo.TextChanged += new System.EventHandler(this.txtStaffNo_TextChanged);
            // 
            // staffNoLabel
            // 
            this.staffNoLabel.AutoSize = true;
            this.staffNoLabel.BackColor = System.Drawing.Color.Transparent;
            this.staffNoLabel.Location = new System.Drawing.Point(11, 56);
            this.staffNoLabel.Name = "staffNoLabel";
            this.staffNoLabel.Size = new System.Drawing.Size(49, 13);
            this.staffNoLabel.TabIndex = 0;
            this.staffNoLabel.Text = "Staff No:";
            this.staffNoLabel.Visible = false;
            // 
            // cmbOption
            // 
            this.cmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Items.AddRange(new object[] {
            "Individual Employee",
            "All Employees"});
            this.cmbOption.Location = new System.Drawing.Point(63, 30);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(145, 21);
            this.cmbOption.TabIndex = 2;
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(22, 78);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Option:";
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            this.searchGrid.BackgroundColor = System.Drawing.Color.White;
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridStaffNo,
            this.gridStaffCode,
            this.gridName});
            this.searchGrid.Location = new System.Drawing.Point(63, 95);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 76);
            this.searchGrid.TabIndex = 6;
            this.searchGrid.Visible = false;
            this.searchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffsID";
            this.gridStaffNo.HeaderText = "Staff No";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // gridStaffCode
            // 
            this.gridStaffCode.HeaderText = "StaffCode";
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.ReadOnly = true;
            this.gridStaffCode.Visible = false;
            // 
            // gridName
            // 
            this.gridName.DataPropertyName = "Name";
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
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
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(230, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Leave Resumption Report Cutomization";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(164, 211);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 24);
            this.btnOK.TabIndex = 32;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(287, 211);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(225, 211);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 24);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // LeaveResumptionReportSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(569, 239);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.MaximizeBox = false;
            this.Name = "LeaveResumptionReportSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave Resumption Report Select";
            this.Load += new System.EventHandler(this.LeaveResumptionReportSelect_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLeaveType;
        private System.Windows.Forms.ComboBox cboLeaveType;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblGradeCategory;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.TextBox txtStaffNo;
        private System.Windows.Forms.Label staffNoLabel;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}