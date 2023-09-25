namespace eMAS.Forms.Reports
{
    partial class AttendanceReportSelect
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
            this.label13 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCheckOutType = new System.Windows.Forms.ComboBox();
            this.comboBoxUsertype = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbintern = new System.Windows.Forms.Label();
            this.comboInterntype = new System.Windows.Forms.ComboBox();
            this.cboShiftType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRptType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboInType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboOutType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.lblType = new System.Windows.Forms.Label();
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
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.staffNoLabel = new System.Windows.Forms.Label();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Staff Attendance Report";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(148, 342);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 24);
            this.btnOK.TabIndex = 32;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(271, 342);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(209, 342);
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
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cboCheckOutType);
            this.panel2.Controls.Add(this.comboBoxUsertype);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lbintern);
            this.panel2.Controls.Add(this.comboInterntype);
            this.panel2.Controls.Add(this.cboShiftType);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboRptType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboInType);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboOutType);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.datePickerFrom);
            this.panel2.Controls.Add(this.datePickerTo);
            this.panel2.Controls.Add(this.lblType);
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
            this.panel2.Controls.Add(this.staffIDtxt);
            this.panel2.Controls.Add(this.staffNoLabel);
            this.panel2.Controls.Add(this.cmbOption);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nametxt);
            this.panel2.Controls.Add(this.searchGrid);
            this.panel2.Location = new System.Drawing.Point(4, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 310);
            this.panel2.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(6, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "CheckOut Type:";
            // 
            // cboCheckOutType
            // 
            this.cboCheckOutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckOutType.FormattingEnabled = true;
            this.cboCheckOutType.Items.AddRange(new object[] {
            "All",
            "Fingerprint",
            "Card",
            "Both"});
            this.cboCheckOutType.Location = new System.Drawing.Point(94, 131);
            this.cboCheckOutType.Name = "cboCheckOutType";
            this.cboCheckOutType.Size = new System.Drawing.Size(146, 21);
            this.cboCheckOutType.TabIndex = 50;
            this.cboCheckOutType.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // comboBoxUsertype
            // 
            this.comboBoxUsertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsertype.FormattingEnabled = true;
            this.comboBoxUsertype.Items.AddRange(new object[] {
            "ALL",
            "EMPLOYEE",
            "INTERNS"});
            this.comboBoxUsertype.Location = new System.Drawing.Point(94, 183);
            this.comboBoxUsertype.Name = "comboBoxUsertype";
            this.comboBoxUsertype.Size = new System.Drawing.Size(145, 21);
            this.comboBoxUsertype.TabIndex = 49;
            this.comboBoxUsertype.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsertype_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(27, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "User type:";
            // 
            // lbintern
            // 
            this.lbintern.AutoSize = true;
            this.lbintern.Location = new System.Drawing.Point(27, 213);
            this.lbintern.Name = "lbintern";
            this.lbintern.Size = new System.Drawing.Size(61, 13);
            this.lbintern.TabIndex = 47;
            this.lbintern.Text = "Intern Type";
            this.lbintern.Visible = false;
            // 
            // comboInterntype
            // 
            this.comboInterntype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInterntype.FormattingEnabled = true;
            this.comboInterntype.Location = new System.Drawing.Point(94, 210);
            this.comboInterntype.Name = "comboInterntype";
            this.comboInterntype.Size = new System.Drawing.Size(189, 21);
            this.comboInterntype.TabIndex = 46;
            this.comboInterntype.Visible = false;
            this.comboInterntype.DropDown += new System.EventHandler(this.comboInterntype_DropDown);
            // 
            // cboShiftType
            // 
            this.cboShiftType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShiftType.FormattingEnabled = true;
            this.cboShiftType.Items.AddRange(new object[] {
            "ATTENDANCE",
            "UNAVAILABLES",
            "LATENESS"});
            this.cboShiftType.Location = new System.Drawing.Point(94, 53);
            this.cboShiftType.Name = "cboShiftType";
            this.cboShiftType.Size = new System.Drawing.Size(146, 21);
            this.cboShiftType.TabIndex = 30;
            this.cboShiftType.DropDown += new System.EventHandler(this.cboShiftType_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(26, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Shift Type";
            // 
            // cboRptType
            // 
            this.cboRptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRptType.FormattingEnabled = true;
            this.cboRptType.Items.AddRange(new object[] {
            "ATTENDANCE",
            "LATENESS"});
            this.cboRptType.Location = new System.Drawing.Point(94, 156);
            this.cboRptType.Name = "cboRptType";
            this.cboRptType.Size = new System.Drawing.Size(146, 21);
            this.cboRptType.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(26, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Report type";
            // 
            // cboInType
            // 
            this.cboInType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInType.FormattingEnabled = true;
            this.cboInType.Items.AddRange(new object[] {
            "All",
            "Fingerprint",
            "Card",
            "Both"});
            this.cboInType.Location = new System.Drawing.Point(94, 78);
            this.cboInType.Name = "cboInType";
            this.cboInType.Size = new System.Drawing.Size(146, 21);
            this.cboInType.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(30, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Check-Out:";
            // 
            // cboOutType
            // 
            this.cboOutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutType.FormattingEnabled = true;
            this.cboOutType.Items.AddRange(new object[] {
            "All",
            "Fingerprint",
            "Card",
            "Both"});
            this.cboOutType.Location = new System.Drawing.Point(94, 103);
            this.cboOutType.Name = "cboOutType";
            this.cboOutType.Size = new System.Drawing.Size(146, 21);
            this.cboOutType.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "From:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "To:";
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Checked = false;
            this.datePickerFrom.CustomFormat = " dd/MM/yyyy";
            this.datePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerFrom.Location = new System.Drawing.Point(94, 5);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.ShowCheckBox = true;
            this.datePickerFrom.Size = new System.Drawing.Size(146, 20);
            this.datePickerFrom.TabIndex = 21;
            this.datePickerFrom.Value = new System.DateTime(2015, 5, 20, 0, 0, 0, 0);
            // 
            // datePickerTo
            // 
            this.datePickerTo.Checked = false;
            this.datePickerTo.CustomFormat = " dd/MM/yyyy";
            this.datePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerTo.Location = new System.Drawing.Point(356, 3);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.ShowCheckBox = true;
            this.datePickerTo.Size = new System.Drawing.Size(148, 20);
            this.datePickerTo.TabIndex = 20;
            this.datePickerTo.Value = new System.DateTime(2015, 5, 20, 0, 0, 0, 0);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Location = new System.Drawing.Point(35, 82);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(56, 13);
            this.lblType.TabIndex = 19;
            this.lblType.Text = "Check-In :";
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(356, 127);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboGrade.Size = new System.Drawing.Size(148, 21);
            this.cboGrade.TabIndex = 17;
            this.cboGrade.Visible = false;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblGrade.Location = new System.Drawing.Point(310, 131);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGrade.Size = new System.Drawing.Size(42, 13);
            this.lblGrade.TabIndex = 16;
            this.lblGrade.Text = "Grade :";
            this.lblGrade.Visible = false;
            // 
            // lblGradeCategory
            // 
            this.lblGradeCategory.AutoSize = true;
            this.lblGradeCategory.Location = new System.Drawing.Point(298, 108);
            this.lblGradeCategory.Name = "lblGradeCategory";
            this.lblGradeCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGradeCategory.Size = new System.Drawing.Size(55, 13);
            this.lblGradeCategory.TabIndex = 15;
            this.lblGradeCategory.Text = "Category :";
            this.lblGradeCategory.Visible = false;
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(356, 103);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboGradeCategory.Size = new System.Drawing.Size(148, 21);
            this.cboGradeCategory.TabIndex = 14;
            this.cboGradeCategory.Visible = false;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(356, 52);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboUnit.Size = new System.Drawing.Size(148, 21);
            this.cboUnit.TabIndex = 13;
            this.cboUnit.Visible = false;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.Location = new System.Drawing.Point(320, 56);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUnit.Size = new System.Drawing.Size(32, 13);
            this.lblUnit.TabIndex = 12;
            this.lblUnit.Text = "Unit :";
            this.lblUnit.Visible = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(285, 33);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(68, 13);
            this.lblDepartment.TabIndex = 11;
            this.lblDepartment.Text = "Department :";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(356, 28);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(148, 21);
            this.cboDepartment.TabIndex = 9;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Location = new System.Drawing.Point(356, 78);
            this.cboZone.Name = "cboZone";
            this.cboZone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboZone.Size = new System.Drawing.Size(148, 21);
            this.cboZone.TabIndex = 10;
            this.cboZone.Visible = false;
            this.cboZone.DropDown += new System.EventHandler(this.cboZone_DropDown);
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.BackColor = System.Drawing.Color.Transparent;
            this.lblZone.Location = new System.Drawing.Point(314, 83);
            this.lblZone.Name = "lblZone";
            this.lblZone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblZone.Size = new System.Drawing.Size(38, 13);
            this.lblZone.TabIndex = 8;
            this.lblZone.Text = "Zone :";
            this.lblZone.Visible = false;
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.staffIDtxt.Location = new System.Drawing.Point(73, 239);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(145, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.Visible = false;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // staffNoLabel
            // 
            this.staffNoLabel.AutoSize = true;
            this.staffNoLabel.BackColor = System.Drawing.Color.Transparent;
            this.staffNoLabel.Location = new System.Drawing.Point(21, 242);
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
            this.cmbOption.Location = new System.Drawing.Point(94, 28);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(146, 21);
            this.cmbOption.TabIndex = 2;
            this.cmbOption.DropDown += new System.EventHandler(this.cmbOption_DropDown);
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(32, 264);
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
            this.label1.Location = new System.Drawing.Point(50, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Option:";
            // 
            // nametxt
            // 
            this.nametxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nametxt.Location = new System.Drawing.Point(73, 261);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(214, 20);
            this.nametxt.TabIndex = 1;
            this.nametxt.Visible = false;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
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
            this.gridName});
            this.searchGrid.Location = new System.Drawing.Point(73, 247);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(235, 52);
            this.searchGrid.TabIndex = 6;
            this.searchGrid.Visible = false;
            this.searchGrid.CellBorderStyleChanged += new System.EventHandler(this.searchGrid_CellBorderStyleChanged);
            this.searchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
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
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffsID";
            this.gridStaffNo.HeaderText = "Staff No";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // gridName
            // 
            this.gridName.DataPropertyName = "Name";
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 150;
            // 
            // AttendanceReportSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(533, 372);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label13);
            this.MaximizeBox = false;
            this.Name = "AttendanceReportSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Attendance Report";
            this.Load += new System.EventHandler(this.AttendanceReportSelect_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.Label lblType;
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
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label staffNoLabel;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboOutType;
        private System.Windows.Forms.ComboBox cboInType;
        private System.Windows.Forms.ComboBox cboRptType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboShiftType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxUsertype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbintern;
        private System.Windows.Forms.ComboBox comboInterntype;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCheckOutType;
    }
}