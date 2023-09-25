namespace eMAS.Forms.PayRollProcessing
{
    partial class OverTimeNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gradeTextBox = new System.Windows.Forms.ComboBox();
            this.gradeCategoryTextBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gendertxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalShifts = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtEmploymentDate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.specialtyTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.departmentTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.agetxt = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.lblOverTimeRate = new System.Windows.Forms.Label();
            this.txtOverTimeRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.checkBoxIsActive = new System.Windows.Forms.CheckBox();
            this.checkBoxIsTaxable = new System.Windows.Forms.CheckBox();
            this.dateHoliday = new System.Windows.Forms.DateTimePicker();
            this.lblHoliday = new System.Windows.Forms.Label();
            this.numericHrsWorked = new System.Windows.Forms.NumericUpDown();
            this.cboOverTimeType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateEntry = new System.Windows.Forms.DateTimePicker();
            this.reasontxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.findbtn = new System.Windows.Forms.Button();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.savebtn = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHrsWorked)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradeTextBox
            // 
            this.gradeTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.gradeTextBox.Enabled = false;
            this.gradeTextBox.FormattingEnabled = true;
            this.gradeTextBox.Location = new System.Drawing.Point(179, 167);
            this.gradeTextBox.Name = "gradeTextBox";
            this.gradeTextBox.Size = new System.Drawing.Size(179, 27);
            this.gradeTextBox.TabIndex = 52;
            // 
            // gradeCategoryTextBox
            // 
            this.gradeCategoryTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.gradeCategoryTextBox.Enabled = false;
            this.gradeCategoryTextBox.FormattingEnabled = true;
            this.gradeCategoryTextBox.Location = new System.Drawing.Point(178, 144);
            this.gradeCategoryTextBox.Name = "gradeCategoryTextBox";
            this.gradeCategoryTextBox.Size = new System.Drawing.Size(180, 24);
            this.gradeCategoryTextBox.TabIndex = 51;
            this.gradeCategoryTextBox.SelectionChangeCommitted += new System.EventHandler(this.gradeCategoryTextBox_SelectionChangeCommitted);
            this.gradeCategoryTextBox.DropDown += new System.EventHandler(this.gradeCategoryTextBox_DropDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(145, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Age:";
            // 
            // gendertxt
            // 
            this.gendertxt.BackColor = System.Drawing.Color.White;
            this.gendertxt.Enabled = false;
            this.gendertxt.Location = new System.Drawing.Point(178, 56);
            this.gendertxt.Name = "gendertxt";
            this.gendertxt.ReadOnly = true;
            this.gendertxt.Size = new System.Drawing.Size(143, 20);
            this.gendertxt.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(130, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Gender:";
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(178, 10);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(143, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Staff ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Reason:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(178, 33);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(222, 20);
            this.nametxt.TabIndex = 1;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTotalShifts);
            this.groupBox1.Controls.Add(this.gradeTextBox);
            this.groupBox1.Controls.Add(this.gradeCategoryTextBox);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtBasicSalary);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.txtEmploymentDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.unitTextBox);
            this.groupBox1.Controls.Add(this.specialtyTextBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.departmentTextBox);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.agetxt);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.gendertxt);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.staffIDtxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nametxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.searchGrid);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 308);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Staff";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Total Shifts:";
            // 
            // txtTotalShifts
            // 
            this.txtTotalShifts.Enabled = false;
            this.txtTotalShifts.Location = new System.Drawing.Point(178, 257);
            this.txtTotalShifts.Name = "txtTotalShifts";
            this.txtTotalShifts.Size = new System.Drawing.Size(100, 20);
            this.txtTotalShifts.TabIndex = 53;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(107, 237);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 13);
            this.label19.TabIndex = 49;
            this.label19.Text = "Basic Salary:";
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Enabled = false;
            this.txtBasicSalary.Location = new System.Drawing.Point(178, 233);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(180, 20);
            this.txtBasicSalary.TabIndex = 46;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(16, 110);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 45;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtEmploymentDate
            // 
            this.txtEmploymentDate.Enabled = false;
            this.txtEmploymentDate.Location = new System.Drawing.Point(178, 211);
            this.txtEmploymentDate.Name = "txtEmploymentDate";
            this.txtEmploymentDate.Size = new System.Drawing.Size(180, 20);
            this.txtEmploymentDate.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(82, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Employment Date:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(146, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Unit:";
            // 
            // unitTextBox
            // 
            this.unitTextBox.Enabled = false;
            this.unitTextBox.Location = new System.Drawing.Point(178, 123);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(180, 20);
            this.unitTextBox.TabIndex = 41;
            // 
            // specialtyTextBox
            // 
            this.specialtyTextBox.Enabled = false;
            this.specialtyTextBox.Location = new System.Drawing.Point(178, 189);
            this.specialtyTextBox.Name = "specialtyTextBox";
            this.specialtyTextBox.Size = new System.Drawing.Size(180, 20);
            this.specialtyTextBox.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(89, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Grade Category :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(123, 193);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Specialty:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(136, 170);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Grade:";
            // 
            // departmentTextBox
            // 
            this.departmentTextBox.BackColor = System.Drawing.Color.White;
            this.departmentTextBox.Enabled = false;
            this.departmentTextBox.Location = new System.Drawing.Point(178, 101);
            this.departmentTextBox.Name = "departmentTextBox";
            this.departmentTextBox.ReadOnly = true;
            this.departmentTextBox.Size = new System.Drawing.Size(180, 20);
            this.departmentTextBox.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(111, 105);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Department:";
            // 
            // agetxt
            // 
            this.agetxt.BackColor = System.Drawing.Color.White;
            this.agetxt.Enabled = false;
            this.agetxt.Location = new System.Drawing.Point(178, 78);
            this.agetxt.Name = "agetxt";
            this.agetxt.ReadOnly = true;
            this.agetxt.Size = new System.Drawing.Size(143, 20);
            this.agetxt.TabIndex = 12;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::eMAS.Properties.Resources._default;
            this.pictureBox.InitialImage = global::eMAS.Properties.Resources._default;
            this.pictureBox.Location = new System.Drawing.Point(9, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(95, 90);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            this.searchGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridName,
            this.gridStaffNo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.searchGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.searchGrid.Location = new System.Drawing.Point(178, 28);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 274);
            this.searchGrid.TabIndex = 19;
            this.searchGrid.Visible = false;
            this.searchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
            // 
            // lblOverTimeRate
            // 
            this.lblOverTimeRate.AutoSize = true;
            this.lblOverTimeRate.Location = new System.Drawing.Point(9, 95);
            this.lblOverTimeRate.Name = "lblOverTimeRate";
            this.lblOverTimeRate.Size = new System.Drawing.Size(79, 13);
            this.lblOverTimeRate.TabIndex = 56;
            this.lblOverTimeRate.Text = "OverTimeRate:";
            // 
            // txtOverTimeRate
            // 
            this.txtOverTimeRate.Enabled = false;
            this.txtOverTimeRate.Location = new System.Drawing.Point(91, 91);
            this.txtOverTimeRate.Name = "txtOverTimeRate";
            this.txtOverTimeRate.Size = new System.Drawing.Size(100, 20);
            this.txtOverTimeRate.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Hrs Worked:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericUpDownAmount);
            this.groupBox2.Controls.Add(this.lblOverTimeRate);
            this.groupBox2.Controls.Add(this.checkBoxIsActive);
            this.groupBox2.Controls.Add(this.checkBoxIsTaxable);
            this.groupBox2.Controls.Add(this.dateHoliday);
            this.groupBox2.Controls.Add(this.txtOverTimeRate);
            this.groupBox2.Controls.Add(this.lblHoliday);
            this.groupBox2.Controls.Add(this.numericHrsWorked);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboOverTimeType);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dateEntry);
            this.groupBox2.Controls.Add(this.reasontxt);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 152);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OverTime Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Amount:";
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.DecimalPlaces = 2;
            this.numericUpDownAmount.Enabled = false;
            this.numericUpDownAmount.Location = new System.Drawing.Point(282, 91);
            this.numericUpDownAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownAmount.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAmount.TabIndex = 57;
            this.numericUpDownAmount.ThousandsSeparator = true;
            // 
            // checkBoxIsActive
            // 
            this.checkBoxIsActive.AutoSize = true;
            this.checkBoxIsActive.Checked = true;
            this.checkBoxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsActive.Location = new System.Drawing.Point(282, 71);
            this.checkBoxIsActive.Name = "checkBoxIsActive";
            this.checkBoxIsActive.Size = new System.Drawing.Size(67, 17);
            this.checkBoxIsActive.TabIndex = 25;
            this.checkBoxIsActive.Text = "Is Active";
            this.checkBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsTaxable
            // 
            this.checkBoxIsTaxable.AutoSize = true;
            this.checkBoxIsTaxable.Checked = true;
            this.checkBoxIsTaxable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsTaxable.Location = new System.Drawing.Point(92, 71);
            this.checkBoxIsTaxable.Name = "checkBoxIsTaxable";
            this.checkBoxIsTaxable.Size = new System.Drawing.Size(81, 17);
            this.checkBoxIsTaxable.TabIndex = 24;
            this.checkBoxIsTaxable.Text = "Is Taxable?";
            this.checkBoxIsTaxable.UseVisualStyleBackColor = true;
            // 
            // dateHoliday
            // 
            this.dateHoliday.Checked = false;
            this.dateHoliday.CustomFormat = "dd/MM/yyyy";
            this.dateHoliday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHoliday.Location = new System.Drawing.Point(282, 45);
            this.dateHoliday.Name = "dateHoliday";
            this.dateHoliday.ShowCheckBox = true;
            this.dateHoliday.Size = new System.Drawing.Size(154, 20);
            this.dateHoliday.TabIndex = 23;
            this.dateHoliday.Visible = false;
            // 
            // lblHoliday
            // 
            this.lblHoliday.AutoSize = true;
            this.lblHoliday.Location = new System.Drawing.Point(234, 48);
            this.lblHoliday.Name = "lblHoliday";
            this.lblHoliday.Size = new System.Drawing.Size(45, 13);
            this.lblHoliday.TabIndex = 22;
            this.lblHoliday.Text = "Holiday:";
            this.lblHoliday.Visible = false;
            // 
            // numericHrsWorked
            // 
            this.numericHrsWorked.DecimalPlaces = 2;
            this.numericHrsWorked.Location = new System.Drawing.Point(91, 45);
            this.numericHrsWorked.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericHrsWorked.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericHrsWorked.Name = "numericHrsWorked";
            this.numericHrsWorked.Size = new System.Drawing.Size(86, 20);
            this.numericHrsWorked.TabIndex = 21;
            this.numericHrsWorked.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHrsWorked.ValueChanged += new System.EventHandler(this.numericHrsWorked_ValueChanged);
            // 
            // cboOverTimeType
            // 
            this.cboOverTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOverTimeType.FormattingEnabled = true;
            this.cboOverTimeType.Location = new System.Drawing.Point(91, 20);
            this.cboOverTimeType.Name = "cboOverTimeType";
            this.cboOverTimeType.Size = new System.Drawing.Size(139, 21);
            this.cboOverTimeType.TabIndex = 18;
            this.cboOverTimeType.SelectedIndexChanged += new System.EventHandler(this.cboOverTimeType_SelectedIndexChanged);
            this.cboOverTimeType.DropDown += new System.EventHandler(this.cboOverTimeType_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "OverTime Type:";
            // 
            // dateEntry
            // 
            this.dateEntry.CustomFormat = "dd/MM/yyyy";
            this.dateEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEntry.Location = new System.Drawing.Point(282, 19);
            this.dateEntry.Name = "dateEntry";
            this.dateEntry.ShowCheckBox = true;
            this.dateEntry.Size = new System.Drawing.Size(154, 20);
            this.dateEntry.TabIndex = 14;
            // 
            // reasontxt
            // 
            this.reasontxt.Location = new System.Drawing.Point(91, 117);
            this.reasontxt.Multiline = true;
            this.reasontxt.Name = "reasontxt";
            this.reasontxt.Size = new System.Drawing.Size(188, 31);
            this.reasontxt.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(8, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Add Over Time";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(502, 32);
            this.panel3.TabIndex = 29;
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(324, 7);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(59, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(194, 7);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(59, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // findbtn
            // 
            this.findbtn.Location = new System.Drawing.Point(259, 7);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(59, 23);
            this.findbtn.TabIndex = 1;
            this.findbtn.Text = "View";
            this.findbtn.UseVisualStyleBackColor = true;
            this.findbtn.Click += new System.EventHandler(this.findbtn_Click);
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.closebtn);
            this.panel2.Controls.Add(this.clearbtn);
            this.panel2.Controls.Add(this.findbtn);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Location = new System.Drawing.Point(0, 512);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 39);
            this.panel2.TabIndex = 32;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(129, 7);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(59, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 155;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // gridName
            // 
            this.gridName.DataPropertyName = "Name";
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 155;
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffsID";
            this.gridStaffNo.HeaderText = "Staff No";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // OverTimeNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 551);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "OverTimeNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OverTime New";
            this.Load += new System.EventHandler(this.OverTimeNew_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHrsWorked)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox gradeTextBox;
        private System.Windows.Forms.ComboBox gradeCategoryTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gendertxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtEmploymentDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.TextBox specialtyTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox departmentTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox agetxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboOverTimeType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateEntry;
        private System.Windows.Forms.TextBox reasontxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button findbtn;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DateTimePicker dateHoliday;
        private System.Windows.Forms.Label lblHoliday;
        private System.Windows.Forms.NumericUpDown numericHrsWorked;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalShifts;
        private System.Windows.Forms.CheckBox checkBoxIsActive;
        private System.Windows.Forms.CheckBox checkBoxIsTaxable;
        private System.Windows.Forms.Label lblOverTimeRate;
        private System.Windows.Forms.TextBox txtOverTimeRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
    }
}