namespace eMAS.Forms.Reports
{
    partial class BankAdviceSlipSelect
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMechanised = new System.Windows.Forms.Label();
            this.cboMechanised = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblGradeCategory = new System.Windows.Forms.Label();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.checkBoxViewSummary = new System.Windows.Forms.CheckBox();
            this.lblBankBranchOne = new System.Windows.Forms.Label();
            this.cboBankBranchOne = new System.Windows.Forms.ComboBox();
            this.lblBankOne = new System.Windows.Forms.Label();
            this.cboBankOne = new System.Windows.Forms.ComboBox();
            this.checkBoxDistribute = new System.Windows.Forms.CheckBox();
            this.periodLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAccountType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.staffNoLabel = new System.Windows.Forms.Label();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkStraightToBank = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 303);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(349, 275);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(257, 276);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(167, 276);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.chkStraightToBank);
            this.panel2.Controls.Add(this.lblMechanised);
            this.panel2.Controls.Add(this.cboMechanised);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cboUnit);
            this.panel2.Controls.Add(this.cboGrade);
            this.panel2.Controls.Add(this.lblGrade);
            this.panel2.Controls.Add(this.lblGradeCategory);
            this.panel2.Controls.Add(this.cboGradeCategory);
            this.panel2.Controls.Add(this.checkBoxViewSummary);
            this.panel2.Controls.Add(this.lblBankBranchOne);
            this.panel2.Controls.Add(this.cboBankBranchOne);
            this.panel2.Controls.Add(this.lblBankOne);
            this.panel2.Controls.Add(this.cboBankOne);
            this.panel2.Controls.Add(this.checkBoxDistribute);
            this.panel2.Controls.Add(this.periodLabel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.yearComboBox);
            this.panel2.Controls.Add(this.monthComboBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtAccountNumber);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cboAccountType);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboBranch);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboBank);
            this.panel2.Controls.Add(this.cboDepartment);
            this.panel2.Controls.Add(this.staffIDtxt);
            this.panel2.Controls.Add(this.staffNoLabel);
            this.panel2.Controls.Add(this.cboZone);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nametxt);
            this.panel2.Controls.Add(this.searchGrid);
            this.panel2.Location = new System.Drawing.Point(5, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 264);
            this.panel2.TabIndex = 8;
            // 
            // lblMechanised
            // 
            this.lblMechanised.AutoSize = true;
            this.lblMechanised.Location = new System.Drawing.Point(326, 165);
            this.lblMechanised.Name = "lblMechanised";
            this.lblMechanised.Size = new System.Drawing.Size(68, 13);
            this.lblMechanised.TabIndex = 89;
            this.lblMechanised.Text = "Mechanised:";
            // 
            // cboMechanised
            // 
            this.cboMechanised.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMechanised.FormattingEnabled = true;
            this.cboMechanised.Location = new System.Drawing.Point(396, 160);
            this.cboMechanised.Name = "cboMechanised";
            this.cboMechanised.Size = new System.Drawing.Size(121, 21);
            this.cboMechanised.TabIndex = 88;
            this.cboMechanised.DropDown += new System.EventHandler(this.cboMechanised_DropDown);
            this.cboMechanised.SelectedIndexChanged += new System.EventHandler(this.cboMechanised_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(361, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Unit :";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(396, 58);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(150, 21);
            this.cboUnit.TabIndex = 31;
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Items.AddRange(new object[] {
            "Pay Roll",
            "Single Pay Slip",
            "All Pay Slips"});
            this.cboGrade.Location = new System.Drawing.Point(79, 164);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(148, 21);
            this.cboGrade.TabIndex = 30;
            this.cboGrade.Visible = false;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblGrade.Location = new System.Drawing.Point(34, 168);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(42, 13);
            this.lblGrade.TabIndex = 29;
            this.lblGrade.Text = "Grade :";
            this.lblGrade.Visible = false;
            // 
            // lblGradeCategory
            // 
            this.lblGradeCategory.AutoSize = true;
            this.lblGradeCategory.Location = new System.Drawing.Point(21, 145);
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
            this.cboGradeCategory.Location = new System.Drawing.Point(79, 141);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(150, 21);
            this.cboGradeCategory.TabIndex = 27;
            this.cboGradeCategory.Visible = false;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // checkBoxViewSummary
            // 
            this.checkBoxViewSummary.AutoSize = true;
            this.checkBoxViewSummary.Location = new System.Drawing.Point(8, 242);
            this.checkBoxViewSummary.Name = "checkBoxViewSummary";
            this.checkBoxViewSummary.Size = new System.Drawing.Size(95, 17);
            this.checkBoxViewSummary.TabIndex = 26;
            this.checkBoxViewSummary.Text = "View Summary";
            this.checkBoxViewSummary.UseVisualStyleBackColor = true;
            // 
            // lblBankBranchOne
            // 
            this.lblBankBranchOne.AutoSize = true;
            this.lblBankBranchOne.Location = new System.Drawing.Point(265, 221);
            this.lblBankBranchOne.Name = "lblBankBranchOne";
            this.lblBankBranchOne.Size = new System.Drawing.Size(107, 13);
            this.lblBankBranchOne.TabIndex = 25;
            this.lblBankBranchOne.Text = "Pay through Branch :";
            this.lblBankBranchOne.Visible = false;
            // 
            // cboBankBranchOne
            // 
            this.cboBankBranchOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBankBranchOne.FormattingEnabled = true;
            this.cboBankBranchOne.Location = new System.Drawing.Point(374, 217);
            this.cboBankBranchOne.Name = "cboBankBranchOne";
            this.cboBankBranchOne.Size = new System.Drawing.Size(150, 21);
            this.cboBankBranchOne.TabIndex = 24;
            this.cboBankBranchOne.Visible = false;
            // 
            // lblBankOne
            // 
            this.lblBankOne.AutoSize = true;
            this.lblBankOne.Location = new System.Drawing.Point(5, 221);
            this.lblBankOne.Name = "lblBankOne";
            this.lblBankOne.Size = new System.Drawing.Size(98, 13);
            this.lblBankOne.TabIndex = 23;
            this.lblBankOne.Text = "Pay through Bank :";
            this.lblBankOne.Visible = false;
            // 
            // cboBankOne
            // 
            this.cboBankOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBankOne.FormattingEnabled = true;
            this.cboBankOne.Location = new System.Drawing.Point(109, 217);
            this.cboBankOne.Name = "cboBankOne";
            this.cboBankOne.Size = new System.Drawing.Size(150, 21);
            this.cboBankOne.TabIndex = 22;
            this.cboBankOne.Visible = false;
            this.cboBankOne.DropDown += new System.EventHandler(this.cboBankOne_DropDown);
            this.cboBankOne.SelectionChangeCommitted += new System.EventHandler(this.cboBankOne_SelectionChangeCommitted);
            // 
            // checkBoxDistribute
            // 
            this.checkBoxDistribute.AutoSize = true;
            this.checkBoxDistribute.Location = new System.Drawing.Point(8, 191);
            this.checkBoxDistribute.Name = "checkBoxDistribute";
            this.checkBoxDistribute.Size = new System.Drawing.Size(194, 17);
            this.checkBoxDistribute.TabIndex = 21;
            this.checkBoxDistribute.Text = "Distribute all advices by one bank : ";
            this.checkBoxDistribute.UseVisualStyleBackColor = true;
            this.checkBoxDistribute.CheckedChanged += new System.EventHandler(this.checkBoxDistribute_CheckedChanged);
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Location = new System.Drawing.Point(31, 10);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(46, 13);
            this.periodLabel.TabIndex = 20;
            this.periodLabel.Text = "Month : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(358, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Year :";
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(396, 8);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(121, 21);
            this.yearComboBox.TabIndex = 18;
            this.yearComboBox.DropDown += new System.EventHandler(this.yearComboBox_DropDown);
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(78, 8);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(148, 21);
            this.monthComboBox.TabIndex = 17;
            this.monthComboBox.DropDown += new System.EventHandler(this.monthComboBox_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Account No.:";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(79, 98);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(147, 20);
            this.txtAccountNumber.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Account Type :";
            // 
            // cboAccountType
            // 
            this.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountType.FormattingEnabled = true;
            this.cboAccountType.Location = new System.Drawing.Point(396, 134);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(149, 21);
            this.cboAccountType.TabIndex = 11;
            this.cboAccountType.DropDown += new System.EventHandler(this.cboAccountType_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Branch :";
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(396, 108);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(150, 21);
            this.cboBranch.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bank :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Department :";
            // 
            // cboBank
            // 
            this.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Location = new System.Drawing.Point(396, 82);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(150, 21);
            this.cboBank.TabIndex = 2;
            this.cboBank.DropDown += new System.EventHandler(this.cboBank_DropDown);
            this.cboBank.SelectionChangeCommitted += new System.EventHandler(this.cboBank_SelectionChangeCommitted);
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(396, 34);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(150, 21);
            this.cboDepartment.TabIndex = 1;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.staffIDtxt.Location = new System.Drawing.Point(79, 56);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(97, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // staffNoLabel
            // 
            this.staffNoLabel.AutoSize = true;
            this.staffNoLabel.BackColor = System.Drawing.Color.Transparent;
            this.staffNoLabel.Location = new System.Drawing.Point(26, 61);
            this.staffNoLabel.Name = "staffNoLabel";
            this.staffNoLabel.Size = new System.Drawing.Size(49, 13);
            this.staffNoLabel.TabIndex = 0;
            this.staffNoLabel.Text = "Staff No:";
            this.staffNoLabel.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Items.AddRange(new object[] {
            "Pay Roll",
            "Single Pay Slip",
            "All Pay Slips"});
            this.cboZone.Location = new System.Drawing.Point(79, 33);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(148, 21);
            this.cboZone.TabIndex = 2;
            this.cboZone.DropDown += new System.EventHandler(this.cboZone_DropDown);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(36, 81);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zone :";
            // 
            // nametxt
            // 
            this.nametxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nametxt.Location = new System.Drawing.Point(79, 77);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(149, 20);
            this.nametxt.TabIndex = 1;
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
            this.searchGrid.Location = new System.Drawing.Point(79, 75);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(228, 64);
            this.searchGrid.TabIndex = 6;
            this.searchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
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
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // chkStraightToBank
            // 
            this.chkStraightToBank.AutoSize = true;
            this.chkStraightToBank.Location = new System.Drawing.Point(396, 191);
            this.chkStraightToBank.Margin = new System.Windows.Forms.Padding(2);
            this.chkStraightToBank.Name = "chkStraightToBank";
            this.chkStraightToBank.Size = new System.Drawing.Size(106, 17);
            this.chkStraightToBank.TabIndex = 91;
            this.chkStraightToBank.Text = "Straight To Bank";
            this.chkStraightToBank.UseVisualStyleBackColor = true;
            // 
            // BankAdviceSlipSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 311);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "BankAdviceSlipSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Advice Slip";
            this.Load += new System.EventHandler(this.BankAdviceSlipSelect_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAccountType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label staffNoLabel;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Label lblBankBranchOne;
        private System.Windows.Forms.ComboBox cboBankBranchOne;
        private System.Windows.Forms.Label lblBankOne;
        private System.Windows.Forms.ComboBox cboBankOne;
        private System.Windows.Forms.CheckBox checkBoxDistribute;
        private System.Windows.Forms.CheckBox checkBoxViewSummary;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblGradeCategory;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label lblMechanised;
        private System.Windows.Forms.ComboBox cboMechanised;
        private System.Windows.Forms.CheckBox chkStraightToBank;

    }
}