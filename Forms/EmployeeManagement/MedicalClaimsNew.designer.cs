namespace eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS
{
    partial class MedicalClaimsNew
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.findbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDOB = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNHIANumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.agetxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gendertxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.payMonth = new System.Windows.Forms.DateTimePicker();
            this.lblPayMonth = new System.Windows.Forms.Label();
            this.checkBoxSupervisorSign = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtSupervisorName = new System.Windows.Forms.TextBox();
            this.receiptNoTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.paidCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.healthFacilityTypecmb = new System.Windows.Forms.ComboBox();
            this.entryDate = new System.Windows.Forms.DateTimePicker();
            this.serviceFacilitytxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.descriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.entryDateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.facilityErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.paymentDateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.serviceDateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.costErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.nameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.receiptNumberErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.gridServices = new System.Windows.Forms.DataGridView();
            this.gridServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridServiceInvestigation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridServiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridServiceSign = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridMedicines = new System.Windows.Forms.DataGridView();
            this.gridMedicineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMedicineDrugs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMedicineQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMedicineAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMedicineSign = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cboRelationship = new System.Windows.Forms.ComboBox();
            this.txtNameOfPatient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPatientAge = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.datePickerPatientDOB = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.checkBoxDoctorSign = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.datePickerDoctorDate = new System.Windows.Forms.DateTimePicker();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtOPDNumber = new System.Windows.Forms.TextBox();
            this.numericUpDownMedicineCost = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownServiceCost = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDownTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entryDateErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facilityErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDateErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDateErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptNumberErrorProvider)).BeginInit();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridServices)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedicines)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedicineCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownServiceCost)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Staff ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(172, 9);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(143, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(172, 31);
            this.nametxt.Name = "nametxt";
            this.nametxt.ReadOnly = true;
            this.nametxt.Size = new System.Drawing.Size(203, 20);
            this.nametxt.TabIndex = 1;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.findbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(0, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 35);
            this.panel1.TabIndex = 11;
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(437, 6);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(67, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(291, 6);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(67, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // findbtn
            // 
            this.findbtn.Location = new System.Drawing.Point(364, 6);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(67, 23);
            this.findbtn.TabIndex = 1;
            this.findbtn.Text = "View";
            this.findbtn.UseVisualStyleBackColor = true;
            this.findbtn.Click += new System.EventHandler(this.findbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(218, 6);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(67, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 18);
            this.panel2.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(14, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "New Medical Claim";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDOB);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtNHIANumber);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtUnit);
            this.groupBox1.Controls.Add(this.txtDepartment);
            this.groupBox1.Controls.Add(this.agetxt);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.gendertxt);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.staffIDtxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nametxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.searchGrid);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 182);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Staff";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "DOB";
            // 
            // txtDOB
            // 
            this.txtDOB.Enabled = false;
            this.txtDOB.Location = new System.Drawing.Point(172, 140);
            this.txtDOB.Multiline = true;
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(143, 21);
            this.txtDOB.TabIndex = 48;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(10, 115);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 47;
            this.btnPreview.Text = "View";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(93, 166);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "NHIA Number:";
            // 
            // txtNHIANumber
            // 
            this.txtNHIANumber.Enabled = false;
            this.txtNHIANumber.Location = new System.Drawing.Point(172, 162);
            this.txtNHIANumber.Name = "txtNHIANumber";
            this.txtNHIANumber.Size = new System.Drawing.Size(143, 20);
            this.txtNHIANumber.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(140, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Unit:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(104, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Department:";
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(172, 118);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(203, 20);
            this.txtUnit.TabIndex = 21;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Location = new System.Drawing.Point(172, 96);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(203, 20);
            this.txtDepartment.TabIndex = 20;
            // 
            // agetxt
            // 
            this.agetxt.BackColor = System.Drawing.Color.White;
            this.agetxt.Enabled = false;
            this.agetxt.Location = new System.Drawing.Point(172, 74);
            this.agetxt.Name = "agetxt";
            this.agetxt.ReadOnly = true;
            this.agetxt.Size = new System.Drawing.Size(143, 20);
            this.agetxt.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(140, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Age:";
            // 
            // gendertxt
            // 
            this.gendertxt.BackColor = System.Drawing.Color.White;
            this.gendertxt.Enabled = false;
            this.gendertxt.Location = new System.Drawing.Point(172, 52);
            this.gendertxt.Name = "gendertxt";
            this.gendertxt.ReadOnly = true;
            this.gendertxt.Size = new System.Drawing.Size(143, 20);
            this.gendertxt.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Gender:";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::eMAS.Properties.Resources._default;
            this.pictureBox.InitialImage = global::eMAS.Properties.Resources._default;
            this.pictureBox.Location = new System.Drawing.Point(5, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(95, 90);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            this.searchGrid.BackgroundColor = System.Drawing.Color.White;
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridName,
            this.gridStaffNo,
            this.gridStaffCode});
            this.searchGrid.Location = new System.Drawing.Point(172, 29);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(232, 153);
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
            // gridStaffCode
            // 
            this.gridStaffCode.HeaderText = "StaffCode";
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.payMonth);
            this.groupBox2.Controls.Add(this.lblPayMonth);
            this.groupBox2.Controls.Add(this.checkBoxSupervisorSign);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txtSupervisorName);
            this.groupBox2.Controls.Add(this.receiptNoTextBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.paidCheckBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.healthFacilityTypecmb);
            this.groupBox2.Controls.Add(this.entryDate);
            this.groupBox2.Controls.Add(this.serviceFacilitytxt);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(7, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 112);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Claim Details";
            // 
            // payMonth
            // 
            this.payMonth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.payMonth.Location = new System.Drawing.Point(350, 41);
            this.payMonth.Name = "payMonth";
            this.payMonth.ShowCheckBox = true;
            this.payMonth.Size = new System.Drawing.Size(120, 20);
            this.payMonth.TabIndex = 39;
            this.payMonth.Visible = false;
            // 
            // lblPayMonth
            // 
            this.lblPayMonth.AutoSize = true;
            this.lblPayMonth.Location = new System.Drawing.Point(270, 45);
            this.lblPayMonth.Name = "lblPayMonth";
            this.lblPayMonth.Size = new System.Drawing.Size(77, 13);
            this.lblPayMonth.TabIndex = 38;
            this.lblPayMonth.Text = "Payment Date:";
            this.lblPayMonth.Visible = false;
            // 
            // checkBoxSupervisorSign
            // 
            this.checkBoxSupervisorSign.AutoSize = true;
            this.checkBoxSupervisorSign.Location = new System.Drawing.Point(273, 89);
            this.checkBoxSupervisorSign.Name = "checkBoxSupervisorSign";
            this.checkBoxSupervisorSign.Size = new System.Drawing.Size(47, 17);
            this.checkBoxSupervisorSign.TabIndex = 37;
            this.checkBoxSupervisorSign.Text = "Sign";
            this.checkBoxSupervisorSign.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 90);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 13);
            this.label25.TabIndex = 36;
            this.label25.Text = "Superv. Name:";
            // 
            // txtSupervisorName
            // 
            this.txtSupervisorName.Location = new System.Drawing.Point(82, 87);
            this.txtSupervisorName.Name = "txtSupervisorName";
            this.txtSupervisorName.Size = new System.Drawing.Size(182, 20);
            this.txtSupervisorName.TabIndex = 35;
            // 
            // receiptNoTextBox
            // 
            this.receiptNoTextBox.Location = new System.Drawing.Point(351, 63);
            this.receiptNoTextBox.Name = "receiptNoTextBox";
            this.receiptNoTextBox.Size = new System.Drawing.Size(119, 20);
            this.receiptNoTextBox.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(284, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Receipt No:";
            // 
            // paidCheckBox
            // 
            this.paidCheckBox.AutoSize = true;
            this.paidCheckBox.Location = new System.Drawing.Point(84, 66);
            this.paidCheckBox.Name = "paidCheckBox";
            this.paidCheckBox.Size = new System.Drawing.Size(47, 17);
            this.paidCheckBox.TabIndex = 30;
            this.paidCheckBox.Text = "Paid";
            this.paidCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Facility Name:";
            // 
            // healthFacilityTypecmb
            // 
            this.healthFacilityTypecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.healthFacilityTypecmb.FormattingEnabled = true;
            this.healthFacilityTypecmb.Location = new System.Drawing.Point(82, 18);
            this.healthFacilityTypecmb.Name = "healthFacilityTypecmb";
            this.healthFacilityTypecmb.Size = new System.Drawing.Size(182, 21);
            this.healthFacilityTypecmb.TabIndex = 28;
            this.healthFacilityTypecmb.DropDown += new System.EventHandler(this.healthFacilityTypecmb_DropDown);
            // 
            // entryDate
            // 
            this.entryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.entryDate.Location = new System.Drawing.Point(350, 17);
            this.entryDate.Name = "entryDate";
            this.entryDate.Size = new System.Drawing.Size(120, 20);
            this.entryDate.TabIndex = 25;
            // 
            // serviceFacilitytxt
            // 
            this.serviceFacilitytxt.Location = new System.Drawing.Point(82, 42);
            this.serviceFacilitytxt.Name = "serviceFacilitytxt";
            this.serviceFacilitytxt.Size = new System.Drawing.Size(183, 20);
            this.serviceFacilitytxt.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Entry Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Facility Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Service Cost:";
            // 
            // descriptionErrorProvider
            // 
            this.descriptionErrorProvider.ContainerControl = this;
            // 
            // entryDateErrorProvider
            // 
            this.entryDateErrorProvider.ContainerControl = this;
            // 
            // facilityErrorProvider
            // 
            this.facilityErrorProvider.ContainerControl = this;
            // 
            // paymentDateErrorProvider
            // 
            this.paymentDateErrorProvider.ContainerControl = this;
            // 
            // serviceDateErrorProvider
            // 
            this.serviceDateErrorProvider.ContainerControl = this;
            // 
            // costErrorProvider
            // 
            this.costErrorProvider.ContainerControl = this;
            // 
            // nameErrorProvider
            // 
            this.nameErrorProvider.ContainerControl = this;
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // receiptNumberErrorProvider
            // 
            this.receiptNumberErrorProvider.ContainerControl = this;
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.Transparent;
            this.groupBox17.Controls.Add(this.gridServices);
            this.groupBox17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox17.ForeColor = System.Drawing.Color.Black;
            this.groupBox17.Location = new System.Drawing.Point(7, 321);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(347, 194);
            this.groupBox17.TabIndex = 17;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "INVESTIGATION/SERVICES";
            // 
            // gridServices
            // 
            this.gridServices.AllowUserToOrderColumns = true;
            this.gridServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridServices.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridServiceID,
            this.gridServiceInvestigation,
            this.gridServiceAmount,
            this.gridServiceSign});
            this.gridServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridServices.GridColor = System.Drawing.Color.Gainsboro;
            this.gridServices.Location = new System.Drawing.Point(3, 17);
            this.gridServices.Name = "gridServices";
            this.gridServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridServices.Size = new System.Drawing.Size(341, 174);
            this.gridServices.TabIndex = 0;
            this.gridServices.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridServices_CurrentCellDirtyStateChanged);
            this.gridServices.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridServices_EditingControlShowing);
            // 
            // gridServiceID
            // 
            this.gridServiceID.HeaderText = "ID";
            this.gridServiceID.Name = "gridServiceID";
            this.gridServiceID.Visible = false;
            // 
            // gridServiceInvestigation
            // 
            this.gridServiceInvestigation.DataPropertyName = "Investigation";
            this.gridServiceInvestigation.FillWeight = 133.2271F;
            this.gridServiceInvestigation.HeaderText = "Investigation";
            this.gridServiceInvestigation.Name = "gridServiceInvestigation";
            this.gridServiceInvestigation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gridServiceAmount
            // 
            this.gridServiceAmount.FillWeight = 90.63071F;
            this.gridServiceAmount.HeaderText = "Amount";
            this.gridServiceAmount.Name = "gridServiceAmount";
            // 
            // gridServiceSign
            // 
            this.gridServiceSign.FillWeight = 76.14214F;
            this.gridServiceSign.HeaderText = "Sign";
            this.gridServiceSign.Name = "gridServiceSign";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.gridMedicines);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(357, 321);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 194);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MEDICINES";
            // 
            // gridMedicines
            // 
            this.gridMedicines.AllowUserToOrderColumns = true;
            this.gridMedicines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMedicines.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridMedicines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridMedicineID,
            this.gridMedicineDrugs,
            this.gridMedicineQuantity,
            this.gridMedicineAmount,
            this.gridMedicineSign});
            this.gridMedicines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMedicines.GridColor = System.Drawing.Color.Gainsboro;
            this.gridMedicines.Location = new System.Drawing.Point(3, 17);
            this.gridMedicines.Name = "gridMedicines";
            this.gridMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMedicines.Size = new System.Drawing.Size(378, 174);
            this.gridMedicines.TabIndex = 0;
            this.gridMedicines.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridMedicines_CurrentCellDirtyStateChanged);
            this.gridMedicines.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridMedicines_EditingControlShowing);
            // 
            // gridMedicineID
            // 
            this.gridMedicineID.HeaderText = "ID";
            this.gridMedicineID.Name = "gridMedicineID";
            this.gridMedicineID.Visible = false;
            // 
            // gridMedicineDrugs
            // 
            this.gridMedicineDrugs.DataPropertyName = "Name";
            this.gridMedicineDrugs.FillWeight = 154.9157F;
            this.gridMedicineDrugs.HeaderText = "Drugs";
            this.gridMedicineDrugs.Name = "gridMedicineDrugs";
            this.gridMedicineDrugs.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gridMedicineQuantity
            // 
            this.gridMedicineQuantity.FillWeight = 63.69926F;
            this.gridMedicineQuantity.HeaderText = "Quantity";
            this.gridMedicineQuantity.Name = "gridMedicineQuantity";
            this.gridMedicineQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMedicineQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridMedicineAmount
            // 
            this.gridMedicineAmount.DataPropertyName = "Amount";
            this.gridMedicineAmount.FillWeight = 79.86224F;
            this.gridMedicineAmount.HeaderText = "Amount";
            this.gridMedicineAmount.Name = "gridMedicineAmount";
            // 
            // gridMedicineSign
            // 
            this.gridMedicineSign.DataPropertyName = "Sign";
            this.gridMedicineSign.FillWeight = 101.5228F;
            this.gridMedicineSign.HeaderText = "Sign";
            this.gridMedicineSign.Name = "gridMedicineSign";
            this.gridMedicineSign.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMedicineSign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cboRelationship
            // 
            this.cboRelationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelationship.FormattingEnabled = true;
            this.cboRelationship.Location = new System.Drawing.Point(94, 13);
            this.cboRelationship.Name = "cboRelationship";
            this.cboRelationship.Size = new System.Drawing.Size(156, 21);
            this.cboRelationship.TabIndex = 34;
            this.cboRelationship.DropDown += new System.EventHandler(this.cboRelationship_DropDown);
            this.cboRelationship.SelectionChangeCommitted += new System.EventHandler(this.cboRelationship_SelectionChangeCommitted);
            // 
            // txtNameOfPatient
            // 
            this.txtNameOfPatient.Location = new System.Drawing.Point(94, 38);
            this.txtNameOfPatient.Name = "txtNameOfPatient";
            this.txtNameOfPatient.Size = new System.Drawing.Size(224, 20);
            this.txtNameOfPatient.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Relationship:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Name of Patient:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(215, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "Age:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPatientAge);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.datePickerPatientDOB);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.checkBoxDoctorSign);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.datePickerDoctorDate);
            this.groupBox4.Controls.Add(this.txtDoctorName);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtDiagnosis);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtOPDNumber);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.cboRelationship);
            this.groupBox4.Controls.Add(this.txtNameOfPatient);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(417, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 182);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Doctor\'s Report";
            // 
            // txtPatientAge
            // 
            this.txtPatientAge.Enabled = false;
            this.txtPatientAge.Location = new System.Drawing.Point(243, 62);
            this.txtPatientAge.Name = "txtPatientAge";
            this.txtPatientAge.Size = new System.Drawing.Size(75, 20);
            this.txtPatientAge.TabIndex = 54;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(23, 66);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 13);
            this.label24.TabIndex = 53;
            this.label24.Text = "Patient DOB:";
            // 
            // datePickerPatientDOB
            // 
            this.datePickerPatientDOB.Checked = false;
            this.datePickerPatientDOB.CustomFormat = "dd/MM/yyyy";
            this.datePickerPatientDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerPatientDOB.Location = new System.Drawing.Point(95, 62);
            this.datePickerPatientDOB.Name = "datePickerPatientDOB";
            this.datePickerPatientDOB.ShowCheckBox = true;
            this.datePickerPatientDOB.Size = new System.Drawing.Size(120, 20);
            this.datePickerPatientDOB.TabIndex = 52;
            this.datePickerPatientDOB.ValueChanged += new System.EventHandler(this.datePickerPatientDOB_ValueChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(58, 159);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 13);
            this.label23.TabIndex = 51;
            this.label23.Text = "Date:";
            // 
            // checkBoxDoctorSign
            // 
            this.checkBoxDoctorSign.AutoSize = true;
            this.checkBoxDoctorSign.Location = new System.Drawing.Point(229, 156);
            this.checkBoxDoctorSign.Name = "checkBoxDoctorSign";
            this.checkBoxDoctorSign.Size = new System.Drawing.Size(47, 17);
            this.checkBoxDoctorSign.TabIndex = 50;
            this.checkBoxDoctorSign.Text = "Sign";
            this.checkBoxDoctorSign.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 134);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 13);
            this.label22.TabIndex = 49;
            this.label22.Text = "Doctor\'s Name";
            // 
            // datePickerDoctorDate
            // 
            this.datePickerDoctorDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerDoctorDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerDoctorDate.Location = new System.Drawing.Point(94, 156);
            this.datePickerDoctorDate.Name = "datePickerDoctorDate";
            this.datePickerDoctorDate.ShowCheckBox = true;
            this.datePickerDoctorDate.Size = new System.Drawing.Size(121, 20);
            this.datePickerDoctorDate.TabIndex = 48;
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Location = new System.Drawing.Point(94, 130);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.Size = new System.Drawing.Size(215, 20);
            this.txtDoctorName.TabIndex = 47;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(35, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 46;
            this.label19.Text = "Diagnosis:";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(94, 106);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(215, 20);
            this.txtDiagnosis.TabIndex = 45;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 88);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 13);
            this.label18.TabIndex = 44;
            this.label18.Text = "OPD/Folder No.:";
            // 
            // txtOPDNumber
            // 
            this.txtOPDNumber.Location = new System.Drawing.Point(94, 84);
            this.txtOPDNumber.Name = "txtOPDNumber";
            this.txtOPDNumber.Size = new System.Drawing.Size(156, 20);
            this.txtOPDNumber.TabIndex = 43;
            // 
            // numericUpDownMedicineCost
            // 
            this.numericUpDownMedicineCost.DecimalPlaces = 2;
            this.numericUpDownMedicineCost.Enabled = false;
            this.numericUpDownMedicineCost.Location = new System.Drawing.Point(83, 38);
            this.numericUpDownMedicineCost.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMedicineCost.Name = "numericUpDownMedicineCost";
            this.numericUpDownMedicineCost.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMedicineCost.TabIndex = 34;
            this.numericUpDownMedicineCost.Tag = "numericupdown";
            this.numericUpDownMedicineCost.ThousandsSeparator = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 13);
            this.label20.TabIndex = 35;
            this.label20.Text = "Medicine Cost:";
            // 
            // numericUpDownServiceCost
            // 
            this.numericUpDownServiceCost.DecimalPlaces = 2;
            this.numericUpDownServiceCost.Enabled = false;
            this.numericUpDownServiceCost.Location = new System.Drawing.Point(83, 14);
            this.numericUpDownServiceCost.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownServiceCost.Name = "numericUpDownServiceCost";
            this.numericUpDownServiceCost.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownServiceCost.TabIndex = 36;
            this.numericUpDownServiceCost.Tag = "numericupdown";
            this.numericUpDownServiceCost.ThousandsSeparator = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.numericUpDownTotalAmount);
            this.groupBox5.Controls.Add(this.numericUpDownServiceCost);
            this.groupBox5.Controls.Add(this.numericUpDownMedicineCost);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(494, 207);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(247, 109);
            this.groupBox5.TabIndex = 44;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Summary";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 67);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 13);
            this.label21.TabIndex = 38;
            this.label21.Text = "Total Amount:";
            // 
            // numericUpDownTotalAmount
            // 
            this.numericUpDownTotalAmount.DecimalPlaces = 2;
            this.numericUpDownTotalAmount.Enabled = false;
            this.numericUpDownTotalAmount.Location = new System.Drawing.Point(83, 64);
            this.numericUpDownTotalAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownTotalAmount.Name = "numericUpDownTotalAmount";
            this.numericUpDownTotalAmount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTotalAmount.TabIndex = 37;
            this.numericUpDownTotalAmount.Tag = "numericupdown";
            this.numericUpDownTotalAmount.ThousandsSeparator = true;
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "StaffCode";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Investigation";
            this.dataGridViewTextBoxColumn5.FillWeight = 133.2271F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Investigation";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.Width = 132;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 90.63071F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "ID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn8.FillWeight = 154.9157F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Drugs";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.Width = 130;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.FillWeight = 63.69926F;
            this.dataGridViewTextBoxColumn9.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 53;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn10.FillWeight = 79.86224F;
            this.dataGridViewTextBoxColumn10.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 67;
            // 
            // MedicalClaimsNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(752, 556);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "MedicalClaimsNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medical_Claims";
            this.Load += new System.EventHandler(this.Medical_Claims_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entryDateErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facilityErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDateErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDateErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptNumberErrorProvider)).EndInit();
            this.groupBox17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridServices)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMedicines)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMedicineCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownServiceCost)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button findbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox healthFacilityTypecmb;
        private System.Windows.Forms.DateTimePicker entryDate;
        private System.Windows.Forms.TextBox serviceFacilitytxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider descriptionErrorProvider;
        private System.Windows.Forms.ErrorProvider entryDateErrorProvider;
        private System.Windows.Forms.ErrorProvider facilityErrorProvider;
        private System.Windows.Forms.ErrorProvider paymentDateErrorProvider;
        private System.Windows.Forms.ErrorProvider serviceDateErrorProvider;
        private System.Windows.Forms.ErrorProvider costErrorProvider;
        private System.Windows.Forms.ErrorProvider nameErrorProvider;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox agetxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gendertxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.TextBox receiptNoTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ErrorProvider receiptNumberErrorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridMedicines;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.DataGridView gridServices;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridServiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridServiceInvestigation;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridServiceAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridServiceSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMedicineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMedicineDrugs;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMedicineQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMedicineAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridMedicineSign;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtNameOfPatient;
        private System.Windows.Forms.ComboBox cboRelationship;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtOPDNumber;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numericUpDownTotalAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownServiceCost;
        private System.Windows.Forms.NumericUpDown numericUpDownMedicineCost;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNHIANumber;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox checkBoxDoctorSign;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker datePickerDoctorDate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker datePickerPatientDOB;
        private System.Windows.Forms.CheckBox checkBoxSupervisorSign;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtSupervisorName;
        private System.Windows.Forms.TextBox txtPatientAge;
        private System.Windows.Forms.CheckBox paidCheckBox;
        private System.Windows.Forms.DateTimePicker payMonth;
        private System.Windows.Forms.Label lblPayMonth;
        private System.Windows.Forms.TextBox txtDOB;
        private System.Windows.Forms.Label label7;
    }
}