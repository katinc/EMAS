namespace eMAS.Forms.TimeAndAttendance
{
    partial class BulkDutyRoaster
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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.viewButton = new System.Windows.Forms.Button();
            this.chkPeriod = new System.Windows.Forms.CheckBox();
            this.bttnClear = new System.Windows.Forms.Button();
            this.bttnAssign = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.StaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbintern = new System.Windows.Forms.Label();
            this.comboInterntype = new System.Windows.Forms.ComboBox();
            this.chkInterns = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxReason = new System.Windows.Forms.TextBox();
            this.comboShfit = new System.Windows.Forms.ComboBox();
            this.dateshift = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkEmployees = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.chkAllusers = new System.Windows.Forms.CheckBox();
            this.bttnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.departmentsComboBox = new System.Windows.Forms.ComboBox();
            this.employeesGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.employeesGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // gName
            // 
            this.gName.DataPropertyName = "Name";
            this.gName.HeaderText = "Name";
            this.gName.Name = "gName";
            this.gName.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.viewButton);
            this.groupBox1.Controls.Add(this.chkPeriod);
            this.groupBox1.Controls.Add(this.bttnClear);
            this.groupBox1.Controls.Add(this.bttnAssign);
            this.groupBox1.Controls.Add(this.listBoxUsers);
            this.groupBox1.Location = new System.Drawing.Point(299, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 442);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users to be Assigned";
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(184, 412);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(69, 23);
            this.viewButton.TabIndex = 21;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // chkPeriod
            // 
            this.chkPeriod.AutoSize = true;
            this.chkPeriod.Location = new System.Drawing.Point(7, 395);
            this.chkPeriod.Name = "chkPeriod";
            this.chkPeriod.Size = new System.Drawing.Size(147, 17);
            this.chkPeriod.TabIndex = 20;
            this.chkPeriod.Text = "Assign to Selected Period";
            this.chkPeriod.UseVisualStyleBackColor = true;
            // 
            // bttnClear
            // 
            this.bttnClear.Location = new System.Drawing.Point(99, 413);
            this.bttnClear.Name = "bttnClear";
            this.bttnClear.Size = new System.Drawing.Size(69, 23);
            this.bttnClear.TabIndex = 19;
            this.bttnClear.Text = "Clear";
            this.bttnClear.UseVisualStyleBackColor = true;
            this.bttnClear.Click += new System.EventHandler(this.bttnClear_Click);
            // 
            // bttnAssign
            // 
            this.bttnAssign.Location = new System.Drawing.Point(3, 413);
            this.bttnAssign.Name = "bttnAssign";
            this.bttnAssign.Size = new System.Drawing.Size(80, 23);
            this.bttnAssign.TabIndex = 18;
            this.bttnAssign.Text = "Assign Shift";
            this.bttnAssign.UseVisualStyleBackColor = true;
            this.bttnAssign.Click += new System.EventHandler(this.bttnAssign_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(3, 17);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(250, 368);
            this.listBoxUsers.TabIndex = 0;
            // 
            // StaffID
            // 
            this.StaffID.DataPropertyName = "staffid";
            this.StaffID.HeaderText = "StaffID";
            this.StaffID.Name = "StaffID";
            this.StaffID.ReadOnly = true;
            // 
            // lbintern
            // 
            this.lbintern.AutoSize = true;
            this.lbintern.Location = new System.Drawing.Point(23, 50);
            this.lbintern.Name = "lbintern";
            this.lbintern.Size = new System.Drawing.Size(61, 13);
            this.lbintern.TabIndex = 27;
            this.lbintern.Text = "Intern Type";
            this.lbintern.Visible = false;
            // 
            // comboInterntype
            // 
            this.comboInterntype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInterntype.FormattingEnabled = true;
            this.comboInterntype.Location = new System.Drawing.Point(91, 47);
            this.comboInterntype.Name = "comboInterntype";
            this.comboInterntype.Size = new System.Drawing.Size(189, 21);
            this.comboInterntype.TabIndex = 26;
            this.comboInterntype.Visible = false;
            this.comboInterntype.DropDown += new System.EventHandler(this.comboInterntype_DropDown);
            // 
            // chkInterns
            // 
            this.chkInterns.AutoSize = true;
            this.chkInterns.Location = new System.Drawing.Point(156, 21);
            this.chkInterns.Name = "chkInterns";
            this.chkInterns.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkInterns.Size = new System.Drawing.Size(58, 17);
            this.chkInterns.TabIndex = 25;
            this.chkInterns.Text = "Interns";
            this.chkInterns.UseVisualStyleBackColor = true;
            this.chkInterns.CheckedChanged += new System.EventHandler(this.chkInterns_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbxReason);
            this.groupBox4.Controls.Add(this.comboShfit);
            this.groupBox4.Controls.Add(this.dateshift);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(299, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 104);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Reason";
            // 
            // tbxReason
            // 
            this.tbxReason.Location = new System.Drawing.Point(85, 68);
            this.tbxReason.Multiline = true;
            this.tbxReason.Name = "tbxReason";
            this.tbxReason.Size = new System.Drawing.Size(168, 30);
            this.tbxReason.TabIndex = 24;
            // 
            // comboShfit
            // 
            this.comboShfit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboShfit.FormattingEnabled = true;
            this.comboShfit.Location = new System.Drawing.Point(85, 16);
            this.comboShfit.Name = "comboShfit";
            this.comboShfit.Size = new System.Drawing.Size(168, 21);
            this.comboShfit.TabIndex = 22;
            this.comboShfit.DropDown += new System.EventHandler(this.comboShfit_DropDown);
            // 
            // dateshift
            // 
            this.dateshift.Enabled = false;
            this.dateshift.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateshift.Location = new System.Drawing.Point(85, 42);
            this.dateshift.Name = "dateshift";
            this.dateshift.Size = new System.Drawing.Size(168, 20);
            this.dateshift.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Date to assign";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Shift";
            // 
            // chkEmployees
            // 
            this.chkEmployees.AutoSize = true;
            this.chkEmployees.Checked = true;
            this.chkEmployees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmployees.Location = new System.Drawing.Point(72, 21);
            this.chkEmployees.Name = "chkEmployees";
            this.chkEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEmployees.Size = new System.Drawing.Size(77, 17);
            this.chkEmployees.TabIndex = 24;
            this.chkEmployees.Text = "Employees";
            this.chkEmployees.UseVisualStyleBackColor = true;
            this.chkEmployees.CheckedChanged += new System.EventHandler(this.chkEmployees_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "EndDate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Start Date";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDatePicker.Location = new System.Drawing.Point(90, 41);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(145, 20);
            this.endDatePicker.TabIndex = 10;
            this.endDatePicker.ValueChanged += new System.EventHandler(this.endDatePicker_ValueChanged);
            // 
            // startDatePicker
            // 
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(90, 15);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(145, 20);
            this.startDatePicker.TabIndex = 9;
            this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(279, 462);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbintern);
            this.groupBox2.Controls.Add(this.comboInterntype);
            this.groupBox2.Controls.Add(this.chkInterns);
            this.groupBox2.Controls.Add(this.chkEmployees);
            this.groupBox2.Controls.Add(this.cboUnit);
            this.groupBox2.Controls.Add(this.lblUnit);
            this.groupBox2.Controls.Add(this.chkAllusers);
            this.groupBox2.Controls.Add(this.bttnSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbxSearch);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.Controls.Add(this.departmentsComboBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 552);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employees";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(91, 108);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboUnit.Size = new System.Drawing.Size(189, 21);
            this.cboUnit.TabIndex = 23;
            this.cboUnit.SelectedIndexChanged += new System.EventHandler(this.cboUnit_SelectedIndexChanged);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.Location = new System.Drawing.Point(53, 112);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUnit.Size = new System.Drawing.Size(32, 13);
            this.lblUnit.TabIndex = 22;
            this.lblUnit.Text = "Unit :";
            // 
            // chkAllusers
            // 
            this.chkAllusers.AutoSize = true;
            this.chkAllusers.Location = new System.Drawing.Point(6, 161);
            this.chkAllusers.Name = "chkAllusers";
            this.chkAllusers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAllusers.Size = new System.Drawing.Size(100, 17);
            this.chkAllusers.TabIndex = 21;
            this.chkAllusers.Text = "Select All Users";
            this.chkAllusers.UseVisualStyleBackColor = true;
            this.chkAllusers.CheckedChanged += new System.EventHandler(this.chkAllusers_CheckedChanged);
            // 
            // bttnSearch
            // 
            this.bttnSearch.Location = new System.Drawing.Point(112, 157);
            this.bttnSearch.Name = "bttnSearch";
            this.bttnSearch.Size = new System.Drawing.Size(168, 23);
            this.bttnSearch.TabIndex = 15;
            this.bttnSearch.Text = "Search";
            this.bttnSearch.UseVisualStyleBackColor = true;
            this.bttnSearch.Click += new System.EventHandler(this.bttnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(91, 135);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(189, 20);
            this.tbxSearch.TabIndex = 13;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.StaffID,
            this.gName});
            this.grid.Location = new System.Drawing.Point(6, 185);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(274, 359);
            this.grid.TabIndex = 7;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // departmentsComboBox
            // 
            this.departmentsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentsComboBox.FormattingEnabled = true;
            this.departmentsComboBox.Location = new System.Drawing.Point(91, 82);
            this.departmentsComboBox.Name = "departmentsComboBox";
            this.departmentsComboBox.Size = new System.Drawing.Size(189, 21);
            this.departmentsComboBox.TabIndex = 11;
            this.departmentsComboBox.DropDown += new System.EventHandler(this.departmentsComboBox_DropDown);
            this.departmentsComboBox.SelectedIndexChanged += new System.EventHandler(this.departmentsComboBox_SelectedIndexChanged);
            this.departmentsComboBox.SelectionChangeCommitted += new System.EventHandler(this.departmentsComboBox_SelectionChangeCommitted);
            // 
            // employeesGroupBox
            // 
            this.employeesGroupBox.Controls.Add(this.listBox1);
            this.employeesGroupBox.Location = new System.Drawing.Point(561, 75);
            this.employeesGroupBox.Name = "employeesGroupBox";
            this.employeesGroupBox.Size = new System.Drawing.Size(285, 481);
            this.employeesGroupBox.TabIndex = 41;
            this.employeesGroupBox.TabStop = false;
            this.employeesGroupBox.Text = "Days";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.endDatePicker);
            this.groupBox3.Controls.Add(this.startDatePicker);
            this.groupBox3.Location = new System.Drawing.Point(561, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 69);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Period";
            // 
            // BulkDutyRoaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.employeesGroupBox);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.Name = "BulkDutyRoaster";
            this.Text = "BulkDutyRoaster";
            this.Load += new System.EventHandler(this.BulkDutyRoaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.employeesGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.CheckBox chkPeriod;
        private System.Windows.Forms.Button bttnClear;
        private System.Windows.Forms.Button bttnAssign;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffID;
        private System.Windows.Forms.Label lbintern;
        private System.Windows.Forms.ComboBox comboInterntype;
        private System.Windows.Forms.CheckBox chkInterns;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxReason;
        private System.Windows.Forms.ComboBox comboShfit;
        private System.Windows.Forms.DateTimePicker dateshift;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkEmployees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.CheckBox chkAllusers;
        private System.Windows.Forms.Button bttnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ComboBox departmentsComboBox;
        private System.Windows.Forms.GroupBox employeesGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}