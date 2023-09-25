namespace eMAS.Forms.StaffInformation
{
    partial class NewVacancy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.gradeComboBox = new System.Windows.Forms.ComboBox();
            this.appointmentTypeComboTos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gradeCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.reasonForVacancyTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.deadLineDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.faxNoTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.contactNoTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.postalAddressTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.requirementsGrid = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.descriptionGrid = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pmbTextBox = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionGridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionGridDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requirementsGridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requirementsGridRequirements = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionGrid)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.viewButton);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(16, 501);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 36);
            this.panel1.TabIndex = 23;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(874, 5);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(60, 23);
            this.viewButton.TabIndex = 3;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.btnView_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1005, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Close";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(940, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(808, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 33);
            this.panel2.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "New Vacancy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Grade";
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(418, 12);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(135, 20);
            this.datePicker.TabIndex = 26;
            // 
            // gradeComboBox
            // 
            this.gradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeComboBox.FormattingEnabled = true;
            this.gradeComboBox.Location = new System.Drawing.Point(107, 36);
            this.gradeComboBox.Name = "gradeComboBox";
            this.gradeComboBox.Size = new System.Drawing.Size(174, 21);
            this.gradeComboBox.TabIndex = 27;
            this.gradeComboBox.DropDown += new System.EventHandler(this.gradeComboBox_DropDown);
            this.gradeComboBox.SelectedIndexChanged += new System.EventHandler(this.gradeComboBox_SelectedIndexChanged);
            // 
            // appointmentTypeComboTos
            // 
            this.appointmentTypeComboTos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appointmentTypeComboTos.FormattingEnabled = true;
            this.appointmentTypeComboTos.Items.AddRange(new object[] {
            "Full Time",
            "Part Time"});
            this.appointmentTypeComboTos.Location = new System.Drawing.Point(107, 61);
            this.appointmentTypeComboTos.Name = "appointmentTypeComboTos";
            this.appointmentTypeComboTos.Size = new System.Drawing.Size(174, 21);
            this.appointmentTypeComboTos.TabIndex = 29;
            this.appointmentTypeComboTos.DropDown += new System.EventHandler(this.appointmentTypeComboTos_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Appointment Type";
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(107, 87);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(174, 21);
            this.departmentComboBox.TabIndex = 31;
            this.departmentComboBox.DropDown += new System.EventHandler(this.departmentComboBox_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Department";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gradeCategoryComboBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.reasonForVacancyTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.departmentComboBox);
            this.groupBox1.Controls.Add(this.gradeComboBox);
            this.groupBox1.Controls.Add(this.statusTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.datePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.deadLineDatePicker);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.appointmentTypeComboTos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(18, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 118);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // gradeCategoryComboBox
            // 
            this.gradeCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeCategoryComboBox.FormattingEnabled = true;
            this.gradeCategoryComboBox.Location = new System.Drawing.Point(107, 11);
            this.gradeCategoryComboBox.Name = "gradeCategoryComboBox";
            this.gradeCategoryComboBox.Size = new System.Drawing.Size(174, 21);
            this.gradeCategoryComboBox.TabIndex = 64;
            this.gradeCategoryComboBox.DropDown += new System.EventHandler(this.gradeCategoryComboBox_DropDown);
            this.gradeCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.gradeCategoryComboBox_SelectedIndexChanged);
            this.gradeCategoryComboBox.SelectionChangeCommitted += new System.EventHandler(this.gradeCategoryComboBox_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Grade Category ";
            // 
            // reasonForVacancyTextBox
            // 
            this.reasonForVacancyTextBox.Location = new System.Drawing.Point(418, 65);
            this.reasonForVacancyTextBox.Name = "reasonForVacancyTextBox";
            this.reasonForVacancyTextBox.Size = new System.Drawing.Size(135, 20);
            this.reasonForVacancyTextBox.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Reason For Vacancy";
            // 
            // statusTextBox
            // 
            this.statusTextBox.BackColor = System.Drawing.Color.White;
            this.statusTextBox.Location = new System.Drawing.Point(418, 91);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(135, 20);
            this.statusTextBox.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(307, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Status";
            // 
            // deadLineDatePicker
            // 
            this.deadLineDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.deadLineDatePicker.Location = new System.Drawing.Point(418, 38);
            this.deadLineDatePicker.Name = "deadLineDatePicker";
            this.deadLineDatePicker.Size = new System.Drawing.Size(135, 20);
            this.deadLineDatePicker.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Deadline";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.faxNoTextBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.contactNoTextBox);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.postalAddressTextBox);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.emailTextBox);
            this.groupBox4.Controls.Add(this.emailLabel);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(583, 37);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(355, 118);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mode Of Application";
            // 
            // faxNoTextBox
            // 
            this.faxNoTextBox.Location = new System.Drawing.Point(109, 91);
            this.faxNoTextBox.Name = "faxNoTextBox";
            this.faxNoTextBox.Size = new System.Drawing.Size(233, 20);
            this.faxNoTextBox.TabIndex = 60;
            this.faxNoTextBox.TextChanged += new System.EventHandler(this.faxNoTextBox_TextChanged);
            this.faxNoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.faxNoTextBox_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Fax No";
            // 
            // contactNoTextBox
            // 
            this.contactNoTextBox.Location = new System.Drawing.Point(109, 68);
            this.contactNoTextBox.Name = "contactNoTextBox";
            this.contactNoTextBox.Size = new System.Drawing.Size(233, 20);
            this.contactNoTextBox.TabIndex = 58;
            this.contactNoTextBox.TextChanged += new System.EventHandler(this.contactNoTextBox_TextChanged);
            this.contactNoTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.contactNoTextBox_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "Contact No(s)";
            // 
            // postalAddressTextBox
            // 
            this.postalAddressTextBox.BackColor = System.Drawing.Color.White;
            this.postalAddressTextBox.Location = new System.Drawing.Point(109, 22);
            this.postalAddressTextBox.Name = "postalAddressTextBox";
            this.postalAddressTextBox.Size = new System.Drawing.Size(233, 20);
            this.postalAddressTextBox.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(29, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Postal Address";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(109, 45);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(233, 20);
            this.emailTextBox.TabIndex = 50;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(29, 47);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 49;
            this.emailLabel.Text = "Email";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.requirementsGrid);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(16, 343);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1078, 158);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            // 
            // requirementsGrid
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.requirementsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.requirementsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.requirementsGrid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.requirementsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requirementsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requirementsGridID,
            this.requirementsGridRequirements});
            this.requirementsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requirementsGrid.Location = new System.Drawing.Point(3, 16);
            this.requirementsGrid.MultiSelect = false;
            this.requirementsGrid.Name = "requirementsGrid";
            this.requirementsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.requirementsGrid.Size = new System.Drawing.Size(1072, 139);
            this.requirementsGrid.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.descriptionGrid);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(16, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1081, 192);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            // 
            // descriptionGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.descriptionGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.descriptionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.descriptionGrid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.descriptionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.descriptionGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionGridID,
            this.descriptionGridDescription});
            this.descriptionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionGrid.Location = new System.Drawing.Point(3, 16);
            this.descriptionGrid.MultiSelect = false;
            this.descriptionGrid.Name = "descriptionGrid";
            this.descriptionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.descriptionGrid.Size = new System.Drawing.Size(1075, 173);
            this.descriptionGrid.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pmbTextBox);
            this.groupBox5.Location = new System.Drawing.Point(944, 37);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(150, 118);
            this.groupBox5.TabIndex = 53;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Private Mail Bag";
            // 
            // pmbTextBox
            // 
            this.pmbTextBox.Location = new System.Drawing.Point(7, 22);
            this.pmbTextBox.Multiline = true;
            this.pmbTextBox.Name = "pmbTextBox";
            this.pmbTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pmbTextBox.Size = new System.Drawing.Size(138, 89);
            this.pmbTextBox.TabIndex = 61;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Job Requirements";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 1036;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Job Description";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 1036;
            // 
            // descriptionGridID
            // 
            this.descriptionGridID.HeaderText = "ID";
            this.descriptionGridID.Name = "descriptionGridID";
            this.descriptionGridID.Visible = false;
            // 
            // descriptionGridDescription
            // 
            this.descriptionGridDescription.HeaderText = "Job Description";
            this.descriptionGridDescription.Name = "descriptionGridDescription";
            // 
            // requirementsGridID
            // 
            this.requirementsGridID.HeaderText = "ID";
            this.requirementsGridID.Name = "requirementsGridID";
            this.requirementsGridID.Visible = false;
            // 
            // requirementsGridRequirements
            // 
            this.requirementsGridRequirements.HeaderText = "Job Requirements";
            this.requirementsGridRequirements.Name = "requirementsGridRequirements";
            // 
            // NewVacancy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1095, 538);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "NewVacancy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vacancy";
            this.Load += new System.EventHandler(this.NewVacancy_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requirementsGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.descriptionGrid)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ComboBox gradeComboBox;
        private System.Windows.Forms.ComboBox appointmentTypeComboTos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox contactNoTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox postalAddressTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker deadLineDatePicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView requirementsGrid;
        private System.Windows.Forms.TextBox faxNoTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox gradeCategoryComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox reasonForVacancyTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView descriptionGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionGridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionGridDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirementsGridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirementsGridRequirements;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox pmbTextBox;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button viewButton;
    }
}