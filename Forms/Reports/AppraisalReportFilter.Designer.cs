namespace eMAS.Forms.Reports
{
    partial class AppraisalReportFilter
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
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.lblLeaveType = new System.Windows.Forms.Label();
            this.cboAppraisalPeriod = new System.Windows.Forms.ComboBox();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblGradeCategory = new System.Windows.Forms.Label();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.txtStaffNo = new System.Windows.Forms.TextBox();
            this.staffNoLabel = new System.Windows.Forms.Label();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffsID";
            this.gridStaffNo.HeaderText = "Staff No";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // txtStaffName
            // 
            this.txtStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffName.Location = new System.Drawing.Point(81, 117);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(243, 20);
            this.txtStaffName.TabIndex = 1;
            this.txtStaffName.Visible = false;
            this.txtStaffName.TextChanged += new System.EventHandler(this.txtStaffName_TextChanged);
            // 
            // gridName
            // 
            this.gridName.DataPropertyName = "Name";
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 150;
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 16);
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
            this.datePickerFrom.Location = new System.Drawing.Point(80, 13);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.ShowCheckBox = true;
            this.datePickerFrom.Size = new System.Drawing.Size(146, 20);
            this.datePickerFrom.TabIndex = 35;
            this.datePickerFrom.Value = new System.DateTime(2015, 5, 20, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 13);
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
            this.datePickerTo.Location = new System.Drawing.Point(481, 9);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.ShowCheckBox = true;
            this.datePickerTo.Size = new System.Drawing.Size(148, 20);
            this.datePickerTo.TabIndex = 33;
            this.datePickerTo.Value = new System.DateTime(2015, 5, 20, 0, 0, 0, 0);
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.AutoSize = true;
            this.lblLeaveType.BackColor = System.Drawing.Color.Transparent;
            this.lblLeaveType.Location = new System.Drawing.Point(388, 37);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(89, 13);
            this.lblLeaveType.TabIndex = 32;
            this.lblLeaveType.Text = "Appraisal Period :";
            // 
            // cboAppraisalPeriod
            // 
            this.cboAppraisalPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAppraisalPeriod.FormattingEnabled = true;
            this.cboAppraisalPeriod.Location = new System.Drawing.Point(481, 34);
            this.cboAppraisalPeriod.Name = "cboAppraisalPeriod";
            this.cboAppraisalPeriod.Size = new System.Drawing.Size(148, 21);
            this.cboAppraisalPeriod.TabIndex = 31;
            this.cboAppraisalPeriod.DropDown += new System.EventHandler(this.cboAppraisalPeriod_DropDown);
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(481, 160);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(148, 21);
            this.cboGrade.TabIndex = 30;
            this.cboGrade.Visible = false;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblGrade.Location = new System.Drawing.Point(436, 164);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(42, 13);
            this.lblGrade.TabIndex = 29;
            this.lblGrade.Text = "Grade :";
            this.lblGrade.Visible = false;
            // 
            // lblGradeCategory
            // 
            this.lblGradeCategory.AutoSize = true;
            this.lblGradeCategory.Location = new System.Drawing.Point(391, 139);
            this.lblGradeCategory.Name = "lblGradeCategory";
            this.lblGradeCategory.Size = new System.Drawing.Size(87, 13);
            this.lblGradeCategory.TabIndex = 28;
            this.lblGradeCategory.Text = "Grade Category :";
            this.lblGradeCategory.Visible = false;
            // 
            // gridStaffCode
            // 
            this.gridStaffCode.HeaderText = "StaffCode";
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.ReadOnly = true;
            this.gridStaffCode.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(481, 136);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(148, 21);
            this.cboGradeCategory.TabIndex = 27;
            this.cboGradeCategory.Visible = false;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(20, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Appraisal Report";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(242, 239);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 24);
            this.btnOK.TabIndex = 32;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(365, 239);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(303, 239);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 24);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.panel2.Controls.Add(this.cboGrade);
            this.panel2.Controls.Add(this.cboAppraisalPeriod);
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
            this.panel2.Controls.Add(this.cboReportType);
            this.panel2.Controls.Add(this.cmbOption);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.searchGrid);
            this.panel2.Location = new System.Drawing.Point(10, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 200);
            this.panel2.TabIndex = 29;
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(481, 85);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(148, 21);
            this.cboUnit.TabIndex = 26;
            this.cboUnit.Visible = false;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.Location = new System.Drawing.Point(445, 89);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(32, 13);
            this.lblUnit.TabIndex = 25;
            this.lblUnit.Text = "Unit :";
            this.lblUnit.Visible = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(410, 66);
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
            this.cboDepartment.Location = new System.Drawing.Point(481, 61);
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
            this.cboZone.Location = new System.Drawing.Point(481, 111);
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
            this.lblZone.Location = new System.Drawing.Point(439, 116);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(38, 13);
            this.lblZone.TabIndex = 21;
            this.lblZone.Text = "Zone :";
            this.lblZone.Visible = false;
            // 
            // txtStaffNo
            // 
            this.txtStaffNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffNo.Location = new System.Drawing.Point(81, 93);
            this.txtStaffNo.Name = "txtStaffNo";
            this.txtStaffNo.Size = new System.Drawing.Size(145, 20);
            this.txtStaffNo.TabIndex = 1;
            this.txtStaffNo.Visible = false;
            this.txtStaffNo.TextChanged += new System.EventHandler(this.txtStaffNo_TextChanged);
            // 
            // staffNoLabel
            // 
            this.staffNoLabel.AutoSize = true;
            this.staffNoLabel.BackColor = System.Drawing.Color.Transparent;
            this.staffNoLabel.Location = new System.Drawing.Point(25, 95);
            this.staffNoLabel.Name = "staffNoLabel";
            this.staffNoLabel.Size = new System.Drawing.Size(49, 13);
            this.staffNoLabel.TabIndex = 0;
            this.staffNoLabel.Text = "Staff No:";
            this.staffNoLabel.Visible = false;
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Individual Employee",
            "All Employees"});
            this.cboReportType.Location = new System.Drawing.Point(80, 39);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(146, 21);
            this.cboReportType.TabIndex = 2;
            this.cboReportType.DropDown += new System.EventHandler(this.cboReportType_DropDown);
            this.cboReportType.SelectionChangeCommitted += new System.EventHandler(this.cboReportType_SelectionChangeCommitted);
            // 
            // cmbOption
            // 
            this.cmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Items.AddRange(new object[] {
            "Individual Employee",
            "All Employees"});
            this.cmbOption.Location = new System.Drawing.Point(80, 66);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(146, 21);
            this.cmbOption.TabIndex = 2;
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(2, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Report Type :";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(36, 119);
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
            this.label1.Location = new System.Drawing.Point(33, 69);
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
            this.searchGrid.Location = new System.Drawing.Point(80, 111);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(260, 86);
            this.searchGrid.TabIndex = 6;
            this.searchGrid.Visible = false;
            this.searchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "StaffCode";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // AppraisalReportFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(668, 273);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "AppraisalReportFilter";
            this.Text = "Appraisal Report";
            this.Load += new System.EventHandler(this.ExcuseDutyReportFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.Label lblLeaveType;
        private System.Windows.Forms.ComboBox cboAppraisalPeriod;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblGradeCategory;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.TextBox txtStaffNo;
        private System.Windows.Forms.Label staffNoLabel;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboReportType;
        private System.Windows.Forms.Label label2;
    }
}