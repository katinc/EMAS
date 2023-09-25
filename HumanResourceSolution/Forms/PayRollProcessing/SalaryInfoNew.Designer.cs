namespace eMAS.Forms.PayRollProcessing
{
    partial class SalaryInfoNew
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
            dal.CloseConnection();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.agetxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gendertxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.bandComboBox = new System.Windows.Forms.ComboBox();
            this.stepComboBox = new System.Windows.Forms.ComboBox();
            this.gradeCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.paymentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.paymentFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.supervisorComboBox = new System.Windows.Forms.ComboBox();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.gradeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.basicSalaryTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtHoursWorked = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.inUseCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.paymentModeComboBox = new System.Windows.Forms.ComboBox();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoursWorked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnView);
            this.groupBox3.Controls.Add(this.agetxt);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.gendertxt);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.pictureBox);
            this.groupBox3.Controls.Add(this.staffIDtxt);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nametxt);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.searchGrid);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(17, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 167);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Staff";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(19, 138);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 20;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // agetxt
            // 
            this.agetxt.BackColor = System.Drawing.Color.White;
            this.agetxt.Location = new System.Drawing.Point(204, 86);
            this.agetxt.Name = "agetxt";
            this.agetxt.ReadOnly = true;
            this.agetxt.Size = new System.Drawing.Size(143, 20);
            this.agetxt.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Age:";
            // 
            // gendertxt
            // 
            this.gendertxt.BackColor = System.Drawing.Color.White;
            this.gendertxt.Location = new System.Drawing.Point(204, 63);
            this.gendertxt.Name = "gendertxt";
            this.gendertxt.ReadOnly = true;
            this.gendertxt.Size = new System.Drawing.Size(143, 20);
            this.gendertxt.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Gender:";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::eMAS.Properties.Resources._default;
            this.pictureBox.InitialImage = global::eMAS.Properties.Resources._default;
            this.pictureBox.Location = new System.Drawing.Point(9, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(109, 117);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(204, 16);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(143, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            this.staffIDtxt.Leave += new System.EventHandler(this.staffIDtxt_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Staff ID:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(204, 40);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(198, 20);
            this.nametxt.TabIndex = 1;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            this.nametxt.Leave += new System.EventHandler(this.nametxt_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name:";
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            this.searchGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.searchGrid.BackgroundColor = System.Drawing.Color.White;
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridName,
            this.gridStaffNo});
            this.searchGrid.Location = new System.Drawing.Point(204, 35);
            this.searchGrid.MultiSelect = false;
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 101);
            this.searchGrid.TabIndex = 19;
            this.searchGrid.Visible = false;
            this.searchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.unitComboBox);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.bandComboBox);
            this.groupBox2.Controls.Add(this.stepComboBox);
            this.groupBox2.Controls.Add(this.gradeCategoryComboBox);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.paymentTypeComboBox);
            this.groupBox2.Controls.Add(this.paymentFrequencyTextBox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.supervisorComboBox);
            this.groupBox2.Controls.Add(this.departmentComboBox);
            this.groupBox2.Controls.Add(this.gradeComboBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(17, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 129);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Details";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "Unit :";
            // 
            // unitComboBox
            // 
            this.unitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.unitComboBox.Enabled = false;
            this.unitComboBox.FormattingEnabled = true;
            this.unitComboBox.Location = new System.Drawing.Point(102, 80);
            this.unitComboBox.Name = "unitComboBox";
            this.unitComboBox.Size = new System.Drawing.Size(173, 20);
            this.unitComboBox.TabIndex = 63;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(61, 106);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 62;
            this.label20.Text = "Step :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(361, 86);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 61;
            this.label19.Text = "Level :";
            // 
            // bandComboBox
            // 
            this.bandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.bandComboBox.Enabled = false;
            this.bandComboBox.FormattingEnabled = true;
            this.bandComboBox.Location = new System.Drawing.Point(409, 81);
            this.bandComboBox.Name = "bandComboBox";
            this.bandComboBox.Size = new System.Drawing.Size(149, 20);
            this.bandComboBox.TabIndex = 55;
            this.bandComboBox.DropDown += new System.EventHandler(this.bandComboBox_DropDown);
            // 
            // stepComboBox
            // 
            this.stepComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.stepComboBox.Enabled = false;
            this.stepComboBox.FormattingEnabled = true;
            this.stepComboBox.Location = new System.Drawing.Point(102, 103);
            this.stepComboBox.Name = "stepComboBox";
            this.stepComboBox.Size = new System.Drawing.Size(173, 20);
            this.stepComboBox.TabIndex = 54;
            this.stepComboBox.DropDown += new System.EventHandler(this.stepComboBox_DropDown);
            // 
            // gradeCategoryComboBox
            // 
            this.gradeCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.gradeCategoryComboBox.Enabled = false;
            this.gradeCategoryComboBox.FormattingEnabled = true;
            this.gradeCategoryComboBox.Location = new System.Drawing.Point(102, 13);
            this.gradeCategoryComboBox.Name = "gradeCategoryComboBox";
            this.gradeCategoryComboBox.Size = new System.Drawing.Size(173, 21);
            this.gradeCategoryComboBox.TabIndex = 53;
            this.gradeCategoryComboBox.SelectionChangeCommitted += new System.EventHandler(this.gradeCategoryComboBox_SelectionChangeCommitted);
            this.gradeCategoryComboBox.DropDown += new System.EventHandler(this.gradeCategoryComboBox_DropDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(16, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(84, 13);
            this.label18.TabIndex = 52;
            this.label18.Text = "Grade Category:";
            // 
            // paymentTypeComboBox
            // 
            this.paymentTypeComboBox.BackColor = System.Drawing.Color.White;
            this.paymentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.paymentTypeComboBox.Enabled = false;
            this.paymentTypeComboBox.FormattingEnabled = true;
            this.paymentTypeComboBox.Location = new System.Drawing.Point(409, 58);
            this.paymentTypeComboBox.Name = "paymentTypeComboBox";
            this.paymentTypeComboBox.Size = new System.Drawing.Size(149, 21);
            this.paymentTypeComboBox.TabIndex = 49;
            // 
            // paymentFrequencyTextBox
            // 
            this.paymentFrequencyTextBox.BackColor = System.Drawing.Color.White;
            this.paymentFrequencyTextBox.Location = new System.Drawing.Point(409, 12);
            this.paymentFrequencyTextBox.Name = "paymentFrequencyTextBox";
            this.paymentFrequencyTextBox.ReadOnly = true;
            this.paymentFrequencyTextBox.Size = new System.Drawing.Size(149, 20);
            this.paymentFrequencyTextBox.TabIndex = 51;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(300, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 13);
            this.label16.TabIndex = 48;
            this.label16.Text = "Payment Frequency:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(323, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 50;
            this.label17.Text = "Payment Type:";
            // 
            // supervisorComboBox
            // 
            this.supervisorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supervisorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supervisorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.supervisorComboBox.Enabled = false;
            this.supervisorComboBox.FormattingEnabled = true;
            this.supervisorComboBox.Location = new System.Drawing.Point(409, 34);
            this.supervisorComboBox.Name = "supervisorComboBox";
            this.supervisorComboBox.Size = new System.Drawing.Size(149, 21);
            this.supervisorComboBox.TabIndex = 44;
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.departmentComboBox.Enabled = false;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(102, 58);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(173, 21);
            this.departmentComboBox.TabIndex = 43;
            this.departmentComboBox.SelectionChangeCommitted += new System.EventHandler(this.departmentComboBox_SelectionChangeCommitted);
            this.departmentComboBox.DropDown += new System.EventHandler(this.departmentComboBox_DropDown);
            // 
            // gradeComboBox
            // 
            this.gradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.gradeComboBox.Enabled = false;
            this.gradeComboBox.FormattingEnabled = true;
            this.gradeComboBox.Location = new System.Drawing.Point(102, 35);
            this.gradeComboBox.Name = "gradeComboBox";
            this.gradeComboBox.Size = new System.Drawing.Size(173, 21);
            this.gradeComboBox.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(59, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Grade:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(339, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Supervisor :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(32, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Department:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(337, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Basic Salary:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(18, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Payment Mode:";
            // 
            // basicSalaryTextBox
            // 
            this.basicSalaryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.basicSalaryTextBox.Location = new System.Drawing.Point(409, 18);
            this.basicSalaryTextBox.Name = "basicSalaryTextBox";
            this.basicSalaryTextBox.Size = new System.Drawing.Size(149, 20);
            this.basicSalaryTextBox.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Salary Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(-1, 492);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 37);
            this.panel1.TabIndex = 46;
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(343, 6);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(59, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(278, 6);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(59, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(213, 6);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(59, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 31);
            this.panel2.TabIndex = 48;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.endDate);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtHoursWorked);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.inUseCheckBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.startDate);
            this.groupBox4.Controls.Add(this.basicSalaryTextBox);
            this.groupBox4.Controls.Add(this.paymentModeComboBox);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox4.Location = new System.Drawing.Point(17, 366);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(593, 120);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Compensation Details";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(351, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "End Date:";
            // 
            // endDate
            // 
            this.endDate.Checked = false;
            this.endDate.CustomFormat = "dd/MM/yyyy";
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(409, 74);
            this.endDate.Name = "endDate";
            this.endDate.ShowCheckBox = true;
            this.endDate.Size = new System.Drawing.Size(149, 20);
            this.endDate.TabIndex = 57;
            this.endDate.ValueChanged += new System.EventHandler(this.endDate_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 56;
            this.label13.Text = "Hours Worked:";
            // 
            // txtHoursWorked
            // 
            this.txtHoursWorked.Location = new System.Drawing.Point(102, 69);
            this.txtHoursWorked.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtHoursWorked.Name = "txtHoursWorked";
            this.txtHoursWorked.Size = new System.Drawing.Size(120, 20);
            this.txtHoursWorked.TabIndex = 55;
            this.txtHoursWorked.ValueChanged += new System.EventHandler(this.txtHoursWorked_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(365, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Active:";
            // 
            // inUseCheckBox
            // 
            this.inUseCheckBox.AutoSize = true;
            this.inUseCheckBox.Checked = true;
            this.inUseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inUseCheckBox.Location = new System.Drawing.Point(409, 47);
            this.inUseCheckBox.Name = "inUseCheckBox";
            this.inUseCheckBox.Size = new System.Drawing.Size(15, 14);
            this.inUseCheckBox.TabIndex = 53;
            this.inUseCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(41, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Start Date:";
            // 
            // startDate
            // 
            this.startDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.startDate.CustomFormat = "dd/MM/yyyy";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(102, 43);
            this.startDate.Name = "startDate";
            this.startDate.ShowCheckBox = true;
            this.startDate.Size = new System.Drawing.Size(142, 20);
            this.startDate.TabIndex = 51;
            // 
            // paymentModeComboBox
            // 
            this.paymentModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentModeComboBox.FormattingEnabled = true;
            this.paymentModeComboBox.Items.AddRange(new object[] {
            "Bank",
            "Cash",
            "Cheque"});
            this.paymentModeComboBox.Location = new System.Drawing.Point(102, 16);
            this.paymentModeComboBox.Name = "paymentModeComboBox";
            this.paymentModeComboBox.Size = new System.Drawing.Size(142, 21);
            this.paymentModeComboBox.TabIndex = 45;
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
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
            // SalaryInfoNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(630, 529);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "SalaryInfoNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalaryInfo";
            this.Load += new System.EventHandler(this.SalaryInfoNew_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoursWorked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox agetxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gendertxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox basicSalaryTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox paymentFrequencyTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox gradeCategoryComboBox;
        private System.Windows.Forms.ComboBox paymentModeComboBox;
        private System.Windows.Forms.ComboBox supervisorComboBox;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.ComboBox gradeComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.ComboBox paymentTypeComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox inUseCheckBox;
        private System.Windows.Forms.ComboBox bandComboBox;
        private System.Windows.Forms.ComboBox stepComboBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox unitComboBox;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.NumericUpDown txtHoursWorked;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker endDate;
    }
}