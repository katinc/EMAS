
namespace eMAS.Forms.EmployeeManagement
{
    partial class StudyLeaveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudyLeaveForm));
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericDurationyears = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.txtProgramme = new System.Windows.Forms.TextBox();
            this.txtInstitution = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateReportingDate = new System.Windows.Forms.DateTimePicker();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPayment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboStudyLeaveType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAnnualLeaveYear = new System.Windows.Forms.TextBox();
            this.txtLeaveDue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.txtEmploymentDate = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.gradeCategoryTextBox = new System.Windows.Forms.TextBox();
            this.gradeTextBox = new System.Windows.Forms.TextBox();
            this.specialtyTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.departmentTextBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.agetxt = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.gendertxt = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDurationyears)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(294, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 13);
            this.label21.TabIndex = 43;
            this.label21.Text = "Duration (yrs) :";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(498, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Study Leave Form";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 40);
            this.panel2.TabIndex = 79;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(417, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 12;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(336, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(0, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 40);
            this.panel1.TabIndex = 78;
            // 
            // numericDurationyears
            // 
            this.numericDurationyears.Location = new System.Drawing.Point(372, 73);
            this.numericDurationyears.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericDurationyears.Name = "numericDurationyears";
            this.numericDurationyears.Size = new System.Drawing.Size(161, 20);
            this.numericDurationyears.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(287, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Area Of Study : ";
            // 
            // txtProgramme
            // 
            this.txtProgramme.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProgramme.Location = new System.Drawing.Point(372, 49);
            this.txtProgramme.Name = "txtProgramme";
            this.txtProgramme.Size = new System.Drawing.Size(161, 20);
            this.txtProgramme.TabIndex = 7;
            // 
            // txtInstitution
            // 
            this.txtInstitution.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInstitution.Location = new System.Drawing.Point(372, 24);
            this.txtInstitution.Name = "txtInstitution";
            this.txtInstitution.Size = new System.Drawing.Size(161, 20);
            this.txtInstitution.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "End Date :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateEndDate);
            this.groupBox1.Controls.Add(this.dateStartDate);
            this.groupBox1.Controls.Add(this.dateReportingDate);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboPayment);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboStudyLeaveType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.numericDurationyears);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtProgramme);
            this.groupBox1.Controls.Add(this.txtInstitution);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 163);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  Leave Details";
            // 
            // dateEndDate
            // 
            this.dateEndDate.CustomFormat = "dd/MM/yyyy";
            this.dateEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndDate.Location = new System.Drawing.Point(102, 99);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Size = new System.Drawing.Size(150, 20);
            this.dateEndDate.TabIndex = 5;
            // 
            // dateStartDate
            // 
            this.dateStartDate.CustomFormat = "dd/MM/yyyy";
            this.dateStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartDate.Location = new System.Drawing.Point(102, 73);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Size = new System.Drawing.Size(150, 20);
            this.dateStartDate.TabIndex = 4;
            // 
            // dateReportingDate
            // 
            this.dateReportingDate.CustomFormat = "dd/MM/yyyy";
            this.dateReportingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateReportingDate.Location = new System.Drawing.Point(102, 49);
            this.dateReportingDate.Name = "dateReportingDate";
            this.dateReportingDate.Size = new System.Drawing.Size(150, 20);
            this.dateReportingDate.TabIndex = 3;
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.White;
            this.txtReason.Location = new System.Drawing.Point(372, 99);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(161, 47);
            this.txtReason.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(322, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Reason:";
            // 
            // cboPayment
            // 
            this.cboPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayment.FormattingEnabled = true;
            this.cboPayment.Location = new System.Drawing.Point(102, 125);
            this.cboPayment.Name = "cboPayment";
            this.cboPayment.Size = new System.Drawing.Size(150, 21);
            this.cboPayment.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Funding :";
            // 
            // cboStudyLeaveType
            // 
            this.cboStudyLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudyLeaveType.FormattingEnabled = true;
            this.cboStudyLeaveType.Location = new System.Drawing.Point(102, 23);
            this.cboStudyLeaveType.Name = "cboStudyLeaveType";
            this.cboStudyLeaveType.Size = new System.Drawing.Size(150, 21);
            this.cboStudyLeaveType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Type :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 21);
            this.button1.TabIndex = 1000;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Start Date :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Reporting Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Institution :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtAnnualLeaveYear);
            this.groupBox2.Controls.Add(this.txtLeaveDue);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Controls.Add(this.txtEmploymentDate);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.unitTextBox);
            this.groupBox2.Controls.Add(this.gradeCategoryTextBox);
            this.groupBox2.Controls.Add(this.gradeTextBox);
            this.groupBox2.Controls.Add(this.specialtyTextBox);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.departmentTextBox);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.agetxt);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.gendertxt);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.pictureBox);
            this.groupBox2.Controls.Add(this.staffIDtxt);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.nametxt);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.searchGrid);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 300);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Staff";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(132, 269);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Leave Year:";
            // 
            // txtAnnualLeaveYear
            // 
            this.txtAnnualLeaveYear.Enabled = false;
            this.txtAnnualLeaveYear.Location = new System.Drawing.Point(203, 267);
            this.txtAnnualLeaveYear.Name = "txtAnnualLeaveYear";
            this.txtAnnualLeaveYear.Size = new System.Drawing.Size(180, 20);
            this.txtAnnualLeaveYear.TabIndex = 43;
            // 
            // txtLeaveDue
            // 
            this.txtLeaveDue.BackColor = System.Drawing.Color.White;
            this.txtLeaveDue.Enabled = false;
            this.txtLeaveDue.Location = new System.Drawing.Point(203, 241);
            this.txtLeaveDue.Name = "txtLeaveDue";
            this.txtLeaveDue.ReadOnly = true;
            this.txtLeaveDue.Size = new System.Drawing.Size(180, 20);
            this.txtLeaveDue.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Current Annual Leave:";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(19, 142);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 33;
            this.btnPreview.Text = "View";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // txtEmploymentDate
            // 
            this.txtEmploymentDate.Location = new System.Drawing.Point(203, 215);
            this.txtEmploymentDate.Name = "txtEmploymentDate";
            this.txtEmploymentDate.Size = new System.Drawing.Size(180, 20);
            this.txtEmploymentDate.TabIndex = 32;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(106, 219);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 13);
            this.label18.TabIndex = 31;
            this.label18.Text = "Employment Date:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(170, 133);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = "Unit:";
            // 
            // unitTextBox
            // 
            this.unitTextBox.Location = new System.Drawing.Point(203, 126);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(180, 20);
            this.unitTextBox.TabIndex = 29;
            // 
            // gradeCategoryTextBox
            // 
            this.gradeCategoryTextBox.Location = new System.Drawing.Point(203, 148);
            this.gradeCategoryTextBox.Name = "gradeCategoryTextBox";
            this.gradeCategoryTextBox.Size = new System.Drawing.Size(180, 20);
            this.gradeCategoryTextBox.TabIndex = 28;
            // 
            // gradeTextBox
            // 
            this.gradeTextBox.Location = new System.Drawing.Point(203, 169);
            this.gradeTextBox.Name = "gradeTextBox";
            this.gradeTextBox.Size = new System.Drawing.Size(180, 20);
            this.gradeTextBox.TabIndex = 26;
            // 
            // specialtyTextBox
            // 
            this.specialtyTextBox.Location = new System.Drawing.Point(203, 191);
            this.specialtyTextBox.Name = "specialtyTextBox";
            this.specialtyTextBox.Size = new System.Drawing.Size(180, 20);
            this.specialtyTextBox.TabIndex = 25;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(113, 151);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(87, 13);
            this.label22.TabIndex = 24;
            this.label22.Text = "Grade Category :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(146, 198);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 13);
            this.label23.TabIndex = 23;
            this.label23.Text = "Specialty:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(160, 176);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "Grade:";
            // 
            // departmentTextBox
            // 
            this.departmentTextBox.BackColor = System.Drawing.Color.White;
            this.departmentTextBox.Location = new System.Drawing.Point(203, 103);
            this.departmentTextBox.Name = "departmentTextBox";
            this.departmentTextBox.ReadOnly = true;
            this.departmentTextBox.Size = new System.Drawing.Size(180, 20);
            this.departmentTextBox.TabIndex = 21;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(132, 110);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 20;
            this.label25.Text = "Department:";
            // 
            // agetxt
            // 
            this.agetxt.BackColor = System.Drawing.Color.White;
            this.agetxt.Location = new System.Drawing.Point(203, 81);
            this.agetxt.Name = "agetxt";
            this.agetxt.ReadOnly = true;
            this.agetxt.Size = new System.Drawing.Size(180, 20);
            this.agetxt.TabIndex = 12;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(167, 88);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 13);
            this.label26.TabIndex = 11;
            this.label26.Text = "Age:";
            // 
            // gendertxt
            // 
            this.gendertxt.BackColor = System.Drawing.Color.White;
            this.gendertxt.Location = new System.Drawing.Point(203, 59);
            this.gendertxt.Name = "gendertxt";
            this.gendertxt.ReadOnly = true;
            this.gendertxt.Size = new System.Drawing.Size(180, 20);
            this.gendertxt.TabIndex = 10;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(152, 66);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(45, 13);
            this.label27.TabIndex = 9;
            this.label27.Text = "Gender:";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(4, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(106, 117);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(203, 15);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(180, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(151, 22);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(46, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Staff ID:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(203, 37);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(180, 20);
            this.nametxt.TabIndex = 1;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(158, 44);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Name:";
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
            this.gridStaffNo});
            this.searchGrid.Location = new System.Drawing.Point(203, 34);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 253);
            this.searchGrid.TabIndex = 47;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 155;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CreatedDate";
            this.dataGridViewTextBoxColumn5.FillWeight = 65.65144F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Date Created";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 143;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 20F;
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Template Length";
            this.dataGridViewTextBoxColumn4.FillWeight = 65.65144F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Template Length";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 143;
            // 
            // StudyLeaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(594, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "StudyLeaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StudyLeaveForm";
            this.Load += new System.EventHandler(this.StudyLeaveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericDurationyears)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numericDurationyears;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtProgramme;
        private System.Windows.Forms.TextBox txtInstitution;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TextBox txtEmploymentDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.TextBox gradeCategoryTextBox;
        private System.Windows.Forms.TextBox gradeTextBox;
        private System.Windows.Forms.TextBox specialtyTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox departmentTextBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox agetxt;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox gendertxt;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cboStudyLeaveType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.DateTimePicker dateStartDate;
        private System.Windows.Forms.DateTimePicker dateReportingDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAnnualLeaveYear;
        private System.Windows.Forms.TextBox txtLeaveDue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.ComboBox cboPayment;
        private System.Windows.Forms.Label label8;
    }
}