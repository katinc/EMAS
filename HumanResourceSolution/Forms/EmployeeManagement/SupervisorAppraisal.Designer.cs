namespace eMAS.Forms.EmployeeManagement
{
    partial class SupervisorAppraisal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.employeesGrid = new System.Windows.Forms.DataGridView();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.questionnaireGrid = new System.Windows.Forms.DataGridView();
            this.gridNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnswer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.evaluationGrid = new System.Windows.Forms.DataGridView();
            this.evaluationGridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evaluationGridQuality = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.evaluationGridRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.supervisorTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.totalScoreTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gradeComboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeesGrid)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionnaireGrid)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationGrid)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(75, -65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 33);
            this.panel2.TabIndex = 52;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "New Employee Appraisal";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.employeesGrid);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(20, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 129);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Staff Who Have performed the Appraisal";
            // 
            // employeesGrid
            // 
            this.employeesGrid.AllowUserToAddRows = false;
            this.employeesGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.employeesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.employeesGrid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.employeesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridStaffID,
            this.gridName});
            this.employeesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesGrid.Location = new System.Drawing.Point(3, 16);
            this.employeesGrid.Name = "employeesGrid";
            this.employeesGrid.ReadOnly = true;
            this.employeesGrid.RowHeadersWidth = 5;
            this.employeesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeesGrid.Size = new System.Drawing.Size(551, 110);
            this.employeesGrid.TabIndex = 1;
            // 
            // gridStaffID
            // 
            this.gridStaffID.HeaderText = "StaffID";
            this.gridStaffID.Name = "gridStaffID";
            this.gridStaffID.ReadOnly = true;
            this.gridStaffID.Width = 158;
            // 
            // gridName
            // 
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 385;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "To";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.endDatePicker);
            this.groupBox4.Controls.Add(this.startDatePicker);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(584, 69);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 63);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Evaluation Period";
            // 
            // endDatePicker
            // 
            this.endDatePicker.CalendarForeColor = System.Drawing.Color.Yellow;
            this.endDatePicker.Checked = false;
            this.endDatePicker.Enabled = false;
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDatePicker.Location = new System.Drawing.Point(72, 38);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(100, 20);
            this.endDatePicker.TabIndex = 45;
            // 
            // startDatePicker
            // 
            this.startDatePicker.CalendarForeColor = System.Drawing.Color.Yellow;
            this.startDatePicker.Checked = false;
            this.startDatePicker.Enabled = false;
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(72, 12);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(100, 20);
            this.startDatePicker.TabIndex = 44;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(0, 562);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(804, 33);
            this.panel3.TabIndex = 53;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(722, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(660, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(597, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button8_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SlateGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label34);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(827, 33);
            this.panel4.TabIndex = 52;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(16, 9);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(123, 13);
            this.label34.TabIndex = 0;
            this.label34.Text = "Appraisal Evaluation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.questionnaireGrid);
            this.groupBox2.Location = new System.Drawing.Point(20, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(764, 154);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Questionairre";
            // 
            // questionnaireGrid
            // 
            this.questionnaireGrid.AllowUserToAddRows = false;
            this.questionnaireGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.questionnaireGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.questionnaireGrid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.questionnaireGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionnaireGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridNo,
            this.gridQuestion,
            this.gridAnswer});
            this.questionnaireGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionnaireGrid.Location = new System.Drawing.Point(3, 16);
            this.questionnaireGrid.Name = "questionnaireGrid";
            this.questionnaireGrid.ReadOnly = true;
            this.questionnaireGrid.RowHeadersWidth = 5;
            this.questionnaireGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.questionnaireGrid.Size = new System.Drawing.Size(758, 135);
            this.questionnaireGrid.TabIndex = 0;
            // 
            // gridNo
            // 
            this.gridNo.HeaderText = "No";
            this.gridNo.Name = "gridNo";
            this.gridNo.ReadOnly = true;
            this.gridNo.Width = 40;
            // 
            // gridQuestion
            // 
            this.gridQuestion.HeaderText = "Question";
            this.gridQuestion.Name = "gridQuestion";
            this.gridQuestion.ReadOnly = true;
            this.gridQuestion.Width = 370;
            // 
            // gridAnswer
            // 
            this.gridAnswer.HeaderText = "Answer";
            this.gridAnswer.Name = "gridAnswer";
            this.gridAnswer.ReadOnly = true;
            this.gridAnswer.Width = 350;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.evaluationGrid);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Location = new System.Drawing.Point(20, 356);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(764, 175);
            this.groupBox5.TabIndex = 59;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Evaluation";
            // 
            // evaluationGrid
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.evaluationGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.evaluationGrid.BackgroundColor = System.Drawing.Color.SlateGray;
            this.evaluationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.evaluationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.evaluationGridID,
            this.evaluationGridQuality,
            this.evaluationGridRating});
            this.evaluationGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluationGrid.Location = new System.Drawing.Point(3, 16);
            this.evaluationGrid.Name = "evaluationGrid";
            this.evaluationGrid.RowHeadersWidth = 5;
            this.evaluationGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.evaluationGrid.Size = new System.Drawing.Size(758, 156);
            this.evaluationGrid.TabIndex = 0;
            // 
            // evaluationGridID
            // 
            this.evaluationGridID.HeaderText = "ID";
            this.evaluationGridID.Name = "evaluationGridID";
            this.evaluationGridID.ReadOnly = true;
            this.evaluationGridID.Visible = false;
            // 
            // evaluationGridQuality
            // 
            this.evaluationGridQuality.HeaderText = "Quality";
            this.evaluationGridQuality.Name = "evaluationGridQuality";
            this.evaluationGridQuality.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.evaluationGridQuality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.evaluationGridQuality.Width = 635;
            // 
            // evaluationGridRating
            // 
            this.evaluationGridRating.HeaderText = "Rating (%)";
            this.evaluationGridRating.Name = "evaluationGridRating";
            this.evaluationGridRating.Width = 125;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Location = new System.Drawing.Point(59, 261);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(672, 144);
            this.groupBox6.TabIndex = 55;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "TECHNICAL KNOWLEDGE: ( Remains current on technical developments in relevant area" +
                "s of expertise and seeks new technical knowledge as necessary.)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Ability To Face Issues";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(361, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(122, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Communications Abilities";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(361, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Organization";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(361, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "Safety Compliance";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(40, 115);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "Dependability";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(40, 89);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Initiative";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(40, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "Flexibility";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(40, 43);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 13);
            this.label23.TabIndex = 33;
            this.label23.Text = "Quality Of Work";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.datePicker);
            this.groupBox3.Controls.Add(this.supervisorTextBox);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(584, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 65);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Date";
            // 
            // datePicker
            // 
            this.datePicker.CalendarForeColor = System.Drawing.Color.Yellow;
            this.datePicker.Checked = false;
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(72, 36);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(100, 20);
            this.datePicker.TabIndex = 42;
            // 
            // supervisorTextBox
            // 
            this.supervisorTextBox.BackColor = System.Drawing.Color.White;
            this.supervisorTextBox.Location = new System.Drawing.Point(72, 11);
            this.supervisorTextBox.Name = "supervisorTextBox";
            this.supervisorTextBox.ReadOnly = true;
            this.supervisorTextBox.Size = new System.Drawing.Size(100, 20);
            this.supervisorTextBox.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Supervisor";
            // 
            // totalScoreTextBox
            // 
            this.totalScoreTextBox.Location = new System.Drawing.Point(693, 535);
            this.totalScoreTextBox.Name = "totalScoreTextBox";
            this.totalScoreTextBox.Size = new System.Drawing.Size(88, 20);
            this.totalScoreTextBox.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(618, 538);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 61;
            this.label9.Text = "Total Score";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(105, 41);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(159, 21);
            this.typeComboBox.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Appraisal Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Grade Category";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(370, 41);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(159, 21);
            this.categoryComboBox.TabIndex = 64;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Grade";
            // 
            // gradeComboBox
            // 
            this.gradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeComboBox.FormattingEnabled = true;
            this.gradeComboBox.Location = new System.Drawing.Point(606, 41);
            this.gradeComboBox.Name = "gradeComboBox";
            this.gradeComboBox.Size = new System.Drawing.Size(159, 21);
            this.gradeComboBox.TabIndex = 66;
            this.gradeComboBox.SelectedIndexChanged += new System.EventHandler(this.gradeComboBox_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "StaffID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 158;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 385;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "What You Dislike About The Company";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Achievements";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Answer";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 350;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn6.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Rating (%)";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // SupervisorAppraisal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(802, 592);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gradeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.totalScoreTextBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox4);
            this.Name = "SupervisorAppraisal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supervisor Appraisal";
            this.Load += new System.EventHandler(this.SupervisorAppraisal_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeesGrid)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionnaireGrid)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.evaluationGrid)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView questionnaireGrid;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView evaluationGrid;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox supervisorTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.TextBox totalScoreTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView employeesGrid;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox gradeComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnswer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn evaluationGridID;
        private System.Windows.Forms.DataGridViewComboBoxColumn evaluationGridQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn evaluationGridRating;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}