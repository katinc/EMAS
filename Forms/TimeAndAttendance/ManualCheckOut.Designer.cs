namespace eMAS.Forms.TimeAndAttendance
{
    partial class ManualCheckOut
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.title1 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.tx = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.tbStaffID = new System.Windows.Forms.TextBox();
            this.attendanceDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCheckInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCheckOutDate = new CalendarColumn();
            this.gridCheckOutTime = new CalendarTimeColumn();
            this.gridDate = new CalendarColumn();
            this.gridCheckOutType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCheckInDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCheckOutDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDeviceStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbNotCheckedOut = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarTimeColumn1 = new CalendarTimeColumn();
            this.calendarTimeColumn2 = new CalendarTimeColumn();
            this.calendarColumn1 = new CalendarColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.title1);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(829, 33);
            this.panel2.TabIndex = 21;
            // 
            // title1
            // 
            this.title1.AutoSize = true;
            this.title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title1.ForeColor = System.Drawing.Color.White;
            this.title1.Location = new System.Drawing.Point(16, 9);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(108, 13);
            this.title1.TabIndex = 0;
            this.title1.Text = "Manual CheckOut";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(105, 66);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(200, 21);
            this.cboUnit.TabIndex = 63;
            this.cboUnit.DropDown += new System.EventHandler(this.cboUnit_DropDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(517, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 47);
            this.btnSearch.TabIndex = 60;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Unit : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Department :";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(105, 39);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(200, 21);
            this.cboDepartment.TabIndex = 55;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // tx
            // 
            this.tx.AutoSize = true;
            this.tx.BackColor = System.Drawing.Color.Transparent;
            this.tx.Location = new System.Drawing.Point(311, 70);
            this.tx.Name = "tx";
            this.tx.Size = new System.Drawing.Size(46, 13);
            this.tx.TabIndex = 64;
            this.tx.Text = "StaffID :";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(316, 44);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 65;
            this.nameLabel.Text = "Name :";
            // 
            // tbStaffID
            // 
            this.tbStaffID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStaffID.Location = new System.Drawing.Point(360, 70);
            this.tbStaffID.Name = "tbStaffID";
            this.tbStaffID.Size = new System.Drawing.Size(149, 20);
            this.tbStaffID.TabIndex = 66;
            this.tbStaffID.TextChanged += new System.EventHandler(this.tbStaffID_TextChanged);
            // 
            // attendanceDatePicker
            // 
            this.attendanceDatePicker.Checked = false;
            this.attendanceDatePicker.CustomFormat = "MM/dd/yyyy";
            this.attendanceDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.attendanceDatePicker.Location = new System.Drawing.Point(105, 93);
            this.attendanceDatePicker.Name = "attendanceDatePicker";
            this.attendanceDatePicker.ShowCheckBox = true;
            this.attendanceDatePicker.Size = new System.Drawing.Size(200, 20);
            this.attendanceDatePicker.TabIndex = 70;
            this.attendanceDatePicker.Value = new System.DateTime(2019, 1, 15, 0, 0, 0, 0);
            this.attendanceDatePicker.CloseUp += new System.EventHandler(this.attedanceDate_CloseUp);
            this.attendanceDatePicker.ValueChanged += new System.EventHandler(this.attedanceDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Attendance Date:";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.grid);
            this.groupBox19.Location = new System.Drawing.Point(7, 119);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(807, 371);
            this.groupBox19.TabIndex = 71;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Attendance";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridSelect,
            this.gridID,
            this.gridStaffID,
            this.gridName,
            this.gridCheckInTime,
            this.gridCheckOutDate,
            this.gridCheckOutTime,
            this.gridDate,
            this.gridCheckOutType,
            this.gridDepartment,
            this.gridUnit,
            this.gridCheckInDeviceID,
            this.gridCheckOutDeviceID,
            this.gridDeviceStaffID});
            this.grid.GridColor = System.Drawing.SystemColors.Control;
            this.grid.Location = new System.Drawing.Point(3, 16);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 23;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(804, 355);
            this.grid.TabIndex = 2;
            this.grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
            this.grid.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_RowLeave);
            // 
            // gridSelect
            // 
            this.gridSelect.HeaderText = "";
            this.gridSelect.Name = "gridSelect";
            this.gridSelect.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSelect.Width = 20;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Width = 50;
            // 
            // gridStaffID
            // 
            this.gridStaffID.HeaderText = "StaffID";
            this.gridStaffID.Name = "gridStaffID";
            this.gridStaffID.ReadOnly = true;
            this.gridStaffID.Width = 50;
            // 
            // gridName
            // 
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 200;
            // 
            // gridCheckInTime
            // 
            this.gridCheckInTime.HeaderText = "Check In Time";
            this.gridCheckInTime.Name = "gridCheckInTime";
            this.gridCheckInTime.ReadOnly = true;
            this.gridCheckInTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCheckInTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridCheckInTime.Width = 150;
            // 
            // gridCheckOutDate
            // 
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.gridCheckOutDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridCheckOutDate.HeaderText = "Check Out Date";
            this.gridCheckOutDate.Name = "gridCheckOutDate";
            this.gridCheckOutDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCheckOutDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridCheckOutDate.Width = 110;
            // 
            // gridCheckOutTime
            // 
            this.gridCheckOutTime.HeaderText = "Check Out Time";
            this.gridCheckOutTime.Name = "gridCheckOutTime";
            this.gridCheckOutTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCheckOutTime.Width = 110;
            // 
            // gridDate
            // 
            this.gridDate.HeaderText = "Attendance Date";
            this.gridDate.Name = "gridDate";
            this.gridDate.ReadOnly = true;
            // 
            // gridCheckOutType
            // 
            this.gridCheckOutType.HeaderText = "CheckOut Type";
            this.gridCheckOutType.Name = "gridCheckOutType";
            this.gridCheckOutType.ReadOnly = true;
            this.gridCheckOutType.Width = 150;
            // 
            // gridDepartment
            // 
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.ReadOnly = true;
            // 
            // gridUnit
            // 
            this.gridUnit.HeaderText = "Unit";
            this.gridUnit.Name = "gridUnit";
            this.gridUnit.ReadOnly = true;
            // 
            // gridCheckInDeviceID
            // 
            this.gridCheckInDeviceID.HeaderText = "In DeviceID";
            this.gridCheckInDeviceID.Name = "gridCheckInDeviceID";
            // 
            // gridCheckOutDeviceID
            // 
            this.gridCheckOutDeviceID.HeaderText = "Out DeviceID";
            this.gridCheckOutDeviceID.Name = "gridCheckOutDeviceID";
            // 
            // gridDeviceStaffID
            // 
            this.gridDeviceStaffID.HeaderText = "D. Staff ID";
            this.gridDeviceStaffID.Name = "gridDeviceStaffID";
            this.gridDeviceStaffID.ReadOnly = true;
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(360, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(246, 20);
            this.tbName.TabIndex = 73;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // cbNotCheckedOut
            // 
            this.cbNotCheckedOut.AutoSize = true;
            this.cbNotCheckedOut.Location = new System.Drawing.Point(360, 98);
            this.cbNotCheckedOut.Name = "cbNotCheckedOut";
            this.cbNotCheckedOut.Size = new System.Drawing.Size(109, 17);
            this.cbNotCheckedOut.TabIndex = 75;
            this.cbNotCheckedOut.Text = "Not Checked Out";
            this.cbNotCheckedOut.UseVisualStyleBackColor = true;
            this.cbNotCheckedOut.CheckedChanged += new System.EventHandler(this.cbCheckedOut_CheckedChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "StaffID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Device Staff ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // calendarTimeColumn1
            // 
            this.calendarTimeColumn1.HeaderText = "gridCheckInTime";
            this.calendarTimeColumn1.Name = "calendarTimeColumn1";
            this.calendarTimeColumn1.ReadOnly = true;
            // 
            // calendarTimeColumn2
            // 
            this.calendarTimeColumn2.HeaderText = "Check Out Time";
            this.calendarTimeColumn2.Name = "calendarTimeColumn2";
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.HeaderText = "Attendance Date";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Check In Device ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Check Out Device ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "User Type";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 33);
            this.panel1.TabIndex = 22;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(590, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 25);
            this.btnClear.TabIndex = 78;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(660, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 25);
            this.btnSave.TabIndex = 77;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(730, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 25);
            this.btnRefresh.TabIndex = 76;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(613, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 89);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Format";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "All dates in the table below \r\nare in Month/Day/Year format.\r\neg. 31st Jan, 2020 " +
    "is displayed\r\nas 01/31/2020.";
            // 
            // ManualCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(818, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbNotCheckedOut);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.groupBox19);
            this.Controls.Add(this.attendanceDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStaffID);
            this.Controls.Add(this.tx);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.cboUnit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "ManualCheckOut";
            this.Text = "ManualCheckOut";
            this.Load += new System.EventHandler(this.ManualCheckOut_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label title1;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label tx;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox tbStaffID;
        private System.Windows.Forms.DateTimePicker attendanceDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.CheckBox cbNotCheckedOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private CalendarTimeColumn calendarTimeColumn1;
        private CalendarTimeColumn calendarTimeColumn2;
        private CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCheckInTime;
        private CalendarColumn gridCheckOutDate;
        private CalendarTimeColumn gridCheckOutTime;
        private CalendarColumn gridDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCheckOutType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCheckInDeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCheckOutDeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDeviceStaffID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}