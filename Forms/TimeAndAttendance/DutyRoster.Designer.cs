namespace eMAS.Forms.TimeAndAttendance
{
    partial class DutyRoster
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
            this.rosterGroupComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.employeesGroupBox = new System.Windows.Forms.GroupBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentsComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sundayCheckBox = new System.Windows.Forms.CheckBox();
            this.saturdayCheckBox = new System.Windows.Forms.CheckBox();
            this.fridayCheckBox = new System.Windows.Forms.CheckBox();
            this.thursdayCheckBox = new System.Windows.Forms.CheckBox();
            this.wednesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.tuesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.mondayCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.shiftTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rosterGroupComboBox
            // 
            this.rosterGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rosterGroupComboBox.FormattingEnabled = true;
            this.rosterGroupComboBox.Location = new System.Drawing.Point(94, 44);
            this.rosterGroupComboBox.Name = "rosterGroupComboBox";
            this.rosterGroupComboBox.Size = new System.Drawing.Size(145, 21);
            this.rosterGroupComboBox.TabIndex = 0;
            this.rosterGroupComboBox.DropDown += new System.EventHandler(this.rosterGroupComboBox_DropDown);
            this.rosterGroupComboBox.SelectedIndexChanged += new System.EventHandler(this.rosterGroupComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // employeesGroupBox
            // 
            this.employeesGroupBox.Controls.Add(this.removeButton);
            this.employeesGroupBox.Controls.Add(this.searchGrid);
            this.employeesGroupBox.Controls.Add(this.label5);
            this.employeesGroupBox.Controls.Add(this.grid);
            this.employeesGroupBox.Controls.Add(this.departmentsComboBox);
            this.employeesGroupBox.Enabled = false;
            this.employeesGroupBox.Location = new System.Drawing.Point(308, 56);
            this.employeesGroupBox.Name = "employeesGroupBox";
            this.employeesGroupBox.Size = new System.Drawing.Size(416, 416);
            this.employeesGroupBox.TabIndex = 4;
            this.employeesGroupBox.TabStop = false;
            this.employeesGroupBox.Text = "Employees";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(350, 386);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 23);
            this.removeButton.TabIndex = 14;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click_1);
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            this.searchGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchGrid.BackgroundColor = System.Drawing.Color.White;
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Location = new System.Drawing.Point(47, 101);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.Size = new System.Drawing.Size(363, 150);
            this.searchGrid.TabIndex = 13;
            this.searchGrid.Visible = false;
            this.searchGrid.Click += new System.EventHandler(this.searchGrid_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Department";
            // 
            // grid
            // 
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridEmpID,
            this.gridName,
            this.gridID,
            this.gridStaffID});
            this.grid.Location = new System.Drawing.Point(6, 59);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(404, 321);
            this.grid.TabIndex = 7;
            this.grid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grid_EditingControlShowing);
            this.grid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            // 
            // gridEmpID
            // 
            this.gridEmpID.HeaderText = "EmpID";
            this.gridEmpID.Name = "gridEmpID";
            this.gridEmpID.Visible = false;
            // 
            // gridName
            // 
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.Visible = false;
            // 
            // gridStaffID
            // 
            this.gridStaffID.HeaderText = "StaffID";
            this.gridStaffID.Name = "gridStaffID";
            this.gridStaffID.Visible = false;
            // 
            // departmentsComboBox
            // 
            this.departmentsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentsComboBox.FormattingEnabled = true;
            this.departmentsComboBox.Location = new System.Drawing.Point(82, 19);
            this.departmentsComboBox.Name = "departmentsComboBox";
            this.departmentsComboBox.Size = new System.Drawing.Size(211, 21);
            this.departmentsComboBox.TabIndex = 11;
            this.departmentsComboBox.DropDown += new System.EventHandler(this.departmentsComboBox_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(648, 488);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Count:";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel.Location = new System.Drawing.Point(697, 488);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(21, 13);
            this.countLabel.TabIndex = 10;
            this.countLabel.Text = "10";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.viewButton);
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(-1, 523);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 43);
            this.panel1.TabIndex = 31;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(610, 8);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(60, 23);
            this.viewButton.TabIndex = 5;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(545, 8);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(60, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(479, 8);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(60, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(675, 8);
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
            this.panel2.Size = new System.Drawing.Size(757, 33);
            this.panel2.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Duty Roster";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sundayCheckBox);
            this.groupBox2.Controls.Add(this.saturdayCheckBox);
            this.groupBox2.Controls.Add(this.fridayCheckBox);
            this.groupBox2.Controls.Add(this.thursdayCheckBox);
            this.groupBox2.Controls.Add(this.wednesdayCheckBox);
            this.groupBox2.Controls.Add(this.tuesdayCheckBox);
            this.groupBox2.Controls.Add(this.mondayCheckBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.shiftTextBox);
            this.groupBox2.Controls.Add(this.rosterGroupComboBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(28, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 315);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Roster Group";
            // 
            // sundayCheckBox
            // 
            this.sundayCheckBox.AutoSize = true;
            this.sundayCheckBox.Enabled = false;
            this.sundayCheckBox.Location = new System.Drawing.Point(21, 197);
            this.sundayCheckBox.Name = "sundayCheckBox";
            this.sundayCheckBox.Size = new System.Drawing.Size(62, 17);
            this.sundayCheckBox.TabIndex = 10;
            this.sundayCheckBox.Text = "Sunday";
            this.sundayCheckBox.UseVisualStyleBackColor = true;
            // 
            // saturdayCheckBox
            // 
            this.saturdayCheckBox.AutoSize = true;
            this.saturdayCheckBox.Enabled = false;
            this.saturdayCheckBox.Location = new System.Drawing.Point(167, 164);
            this.saturdayCheckBox.Name = "saturdayCheckBox";
            this.saturdayCheckBox.Size = new System.Drawing.Size(68, 17);
            this.saturdayCheckBox.TabIndex = 9;
            this.saturdayCheckBox.Text = "Saturday";
            this.saturdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // fridayCheckBox
            // 
            this.fridayCheckBox.AutoSize = true;
            this.fridayCheckBox.Enabled = false;
            this.fridayCheckBox.Location = new System.Drawing.Point(94, 164);
            this.fridayCheckBox.Name = "fridayCheckBox";
            this.fridayCheckBox.Size = new System.Drawing.Size(54, 17);
            this.fridayCheckBox.TabIndex = 8;
            this.fridayCheckBox.Text = "Friday";
            this.fridayCheckBox.UseVisualStyleBackColor = true;
            // 
            // thursdayCheckBox
            // 
            this.thursdayCheckBox.AutoSize = true;
            this.thursdayCheckBox.Enabled = false;
            this.thursdayCheckBox.Location = new System.Drawing.Point(21, 164);
            this.thursdayCheckBox.Name = "thursdayCheckBox";
            this.thursdayCheckBox.Size = new System.Drawing.Size(70, 17);
            this.thursdayCheckBox.TabIndex = 7;
            this.thursdayCheckBox.Text = "Thursday";
            this.thursdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // wednesdayCheckBox
            // 
            this.wednesdayCheckBox.AutoSize = true;
            this.wednesdayCheckBox.Enabled = false;
            this.wednesdayCheckBox.Location = new System.Drawing.Point(167, 129);
            this.wednesdayCheckBox.Name = "wednesdayCheckBox";
            this.wednesdayCheckBox.Size = new System.Drawing.Size(83, 17);
            this.wednesdayCheckBox.TabIndex = 6;
            this.wednesdayCheckBox.Text = "Wednesday";
            this.wednesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // tuesdayCheckBox
            // 
            this.tuesdayCheckBox.AutoSize = true;
            this.tuesdayCheckBox.Enabled = false;
            this.tuesdayCheckBox.Location = new System.Drawing.Point(94, 129);
            this.tuesdayCheckBox.Name = "tuesdayCheckBox";
            this.tuesdayCheckBox.Size = new System.Drawing.Size(67, 17);
            this.tuesdayCheckBox.TabIndex = 5;
            this.tuesdayCheckBox.Text = "Tuesday";
            this.tuesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // mondayCheckBox
            // 
            this.mondayCheckBox.AutoSize = true;
            this.mondayCheckBox.Enabled = false;
            this.mondayCheckBox.Location = new System.Drawing.Point(21, 129);
            this.mondayCheckBox.Name = "mondayCheckBox";
            this.mondayCheckBox.Size = new System.Drawing.Size(64, 17);
            this.mondayCheckBox.TabIndex = 4;
            this.mondayCheckBox.Text = "Monday";
            this.mondayCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Shift";
            // 
            // shiftTextBox
            // 
            this.shiftTextBox.BackColor = System.Drawing.Color.White;
            this.shiftTextBox.Location = new System.Drawing.Point(94, 71);
            this.shiftTextBox.Name = "shiftTextBox";
            this.shiftTextBox.ReadOnly = true;
            this.shiftTextBox.Size = new System.Drawing.Size(145, 20);
            this.shiftTextBox.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.endDatePicker);
            this.groupBox3.Controls.Add(this.startDatePicker);
            this.groupBox3.Location = new System.Drawing.Point(28, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 100);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Period";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "EndDate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Start Date";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDatePicker.Location = new System.Drawing.Point(94, 53);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(145, 20);
            this.endDatePicker.TabIndex = 10;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(94, 27);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(145, 20);
            this.startDatePicker.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 266;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 320;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 361;
            // 
            // DutyRoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 562);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.employeesGroupBox);
            this.MaximizeBox = false;
            this.Name = "DutyRoster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DutyRoster";
            this.Load += new System.EventHandler(this.DutyRoster_Load);
            this.employeesGroupBox.ResumeLayout(false);
            this.employeesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox rosterGroupComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox employeesGroupBox;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox departmentsComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox shiftTextBox;
        private System.Windows.Forms.CheckBox sundayCheckBox;
        private System.Windows.Forms.CheckBox saturdayCheckBox;
        private System.Windows.Forms.CheckBox fridayCheckBox;
        private System.Windows.Forms.CheckBox thursdayCheckBox;
        private System.Windows.Forms.CheckBox wednesdayCheckBox;
        private System.Windows.Forms.CheckBox tuesdayCheckBox;
        private System.Windows.Forms.CheckBox mondayCheckBox;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
    }
}