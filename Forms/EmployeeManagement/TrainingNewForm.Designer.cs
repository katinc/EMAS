namespace eMAS.Forms.EmployeeManagement
{
    partial class TrainingNewForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.moreButton = new System.Windows.Forms.Button();
            this.agetxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gendertxt = new System.Windows.Forms.TextBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownNumberOfDays = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.gridTrainingCosts = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTrainingAllowanceType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridCurrency = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbOrganizers = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.cmbProgramme = new System.Windows.Forms.TextBox();
            this.txtLocationType = new System.Windows.Forms.TextBox();
            this.txtCertificate = new System.Windows.Forms.TextBox();
            this.txtVenue = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbSponsor = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTrainingDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTrainingType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTrainingAllowanceType = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrainingCosts)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 30);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Training Form";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.moreButton);
            this.groupBox1.Controls.Add(this.agetxt);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.gendertxt);
            this.groupBox1.Controls.Add(this.btnImage);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.staffIDtxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nametxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.searchGrid);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Location = new System.Drawing.Point(1, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Staff";
            // 
            // moreButton
            // 
            this.moreButton.Enabled = false;
            this.moreButton.Location = new System.Drawing.Point(344, 16);
            this.moreButton.Name = "moreButton";
            this.moreButton.Size = new System.Drawing.Size(67, 23);
            this.moreButton.TabIndex = 29;
            this.moreButton.Text = "More...";
            this.moreButton.UseVisualStyleBackColor = true;
            this.moreButton.Visible = false;
            this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
            // 
            // agetxt
            // 
            this.agetxt.BackColor = System.Drawing.Color.White;
            this.agetxt.Location = new System.Drawing.Point(180, 80);
            this.agetxt.Name = "agetxt";
            this.agetxt.ReadOnly = true;
            this.agetxt.Size = new System.Drawing.Size(143, 20);
            this.agetxt.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(112, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Age:";
            // 
            // gendertxt
            // 
            this.gendertxt.BackColor = System.Drawing.Color.White;
            this.gendertxt.Location = new System.Drawing.Point(180, 57);
            this.gendertxt.Name = "gendertxt";
            this.gendertxt.ReadOnly = true;
            this.gendertxt.Size = new System.Drawing.Size(143, 20);
            this.gendertxt.TabIndex = 25;
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(17, 110);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.TabIndex = 0;
            this.btnImage.Text = "view";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Visible = false;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(112, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Gender:";
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(180, 15);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(143, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Staff ID:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(180, 36);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(143, 20);
            this.nametxt.TabIndex = 22;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Name:";
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
            this.searchGrid.Location = new System.Drawing.Point(180, 36);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 80);
            this.searchGrid.TabIndex = 28;
            this.searchGrid.Visible = false;
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
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::eMAS.Properties.Resources._default;
            this.pictureBox.InitialImage = global::eMAS.Properties.Resources._default;
            this.pictureBox.Location = new System.Drawing.Point(11, 14);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(95, 90);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownNumberOfDays);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.gridTrainingCosts);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cmbOrganizers);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtHours);
            this.groupBox2.Controls.Add(this.cmbProgramme);
            this.groupBox2.Controls.Add(this.txtLocationType);
            this.groupBox2.Controls.Add(this.txtCertificate);
            this.groupBox2.Controls.Add(this.txtVenue);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.cmbSponsor);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dateEndDate);
            this.groupBox2.Controls.Add(this.dateStartDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dateTrainingDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboTrainingType);
            this.groupBox2.Location = new System.Drawing.Point(3, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 396);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Training Details";
            // 
            // numericUpDownNumberOfDays
            // 
            this.numericUpDownNumberOfDays.Location = new System.Drawing.Point(112, 141);
            this.numericUpDownNumberOfDays.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownNumberOfDays.Name = "numericUpDownNumberOfDays";
            this.numericUpDownNumberOfDays.ReadOnly = true;
            this.numericUpDownNumberOfDays.Size = new System.Drawing.Size(170, 20);
            this.numericUpDownNumberOfDays.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Duration(days) :";
            // 
            // gridTrainingCosts
            // 
            this.gridTrainingCosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTrainingCosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridTrainingAllowanceType,
            this.gridCurrency,
            this.gridCost});
            this.gridTrainingCosts.Location = new System.Drawing.Point(9, 166);
            this.gridTrainingCosts.Margin = new System.Windows.Forms.Padding(2);
            this.gridTrainingCosts.Name = "gridTrainingCosts";
            this.gridTrainingCosts.RowTemplate.Height = 24;
            this.gridTrainingCosts.Size = new System.Drawing.Size(582, 207);
            this.gridTrainingCosts.TabIndex = 21;
            this.gridTrainingCosts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            // 
            // gridTrainingAllowanceType
            // 
            this.gridTrainingAllowanceType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridTrainingAllowanceType.HeaderText = "Cost of Training";
            this.gridTrainingAllowanceType.Name = "gridTrainingAllowanceType";
            this.gridTrainingAllowanceType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTrainingAllowanceType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridCurrency
            // 
            this.gridCurrency.HeaderText = "Currency";
            this.gridCurrency.Name = "gridCurrency";
            this.gridCurrency.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCurrency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridCurrency.Visible = false;
            this.gridCurrency.Width = 150;
            // 
            // gridCost
            // 
            this.gridCost.HeaderText = "Amount (GHc)";
            this.gridCost.Name = "gridCost";
            this.gridCost.Width = 150;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Programme/Course:";
            // 
            // cmbOrganizers
            // 
            this.cmbOrganizers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganizers.FormattingEnabled = true;
            this.cmbOrganizers.Location = new System.Drawing.Point(423, 15);
            this.cmbOrganizers.Name = "cmbOrganizers";
            this.cmbOrganizers.Size = new System.Drawing.Size(168, 21);
            this.cmbOrganizers.TabIndex = 32;
            this.cmbOrganizers.DropDown += new System.EventHandler(this.cmbOrganizers_DropDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(341, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Hours per day :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(376, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Venue :";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(423, 141);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(169, 20);
            this.txtHours.TabIndex = 30;
            // 
            // cmbProgramme
            // 
            this.cmbProgramme.Location = new System.Drawing.Point(112, 63);
            this.cmbProgramme.Name = "cmbProgramme";
            this.cmbProgramme.Size = new System.Drawing.Size(169, 20);
            this.cmbProgramme.TabIndex = 30;
            // 
            // txtLocationType
            // 
            this.txtLocationType.Location = new System.Drawing.Point(422, 66);
            this.txtLocationType.Name = "txtLocationType";
            this.txtLocationType.Size = new System.Drawing.Size(169, 20);
            this.txtLocationType.TabIndex = 30;
            // 
            // txtCertificate
            // 
            this.txtCertificate.Location = new System.Drawing.Point(422, 89);
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Size = new System.Drawing.Size(169, 20);
            this.txtCertificate.TabIndex = 30;
            // 
            // txtVenue
            // 
            this.txtVenue.Location = new System.Drawing.Point(423, 115);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.Size = new System.Drawing.Size(169, 20);
            this.txtVenue.TabIndex = 30;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(321, 92);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "Certificate Awarded :";
            // 
            // cmbSponsor
            // 
            this.cmbSponsor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSponsor.FormattingEnabled = true;
            this.cmbSponsor.Location = new System.Drawing.Point(423, 40);
            this.cmbSponsor.Name = "cmbSponsor";
            this.cmbSponsor.Size = new System.Drawing.Size(169, 21);
            this.cmbSponsor.TabIndex = 26;
            this.cmbSponsor.DropDown += new System.EventHandler(this.cboSponsor_DropDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(362, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "Location :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(367, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Sponsor :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(357, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Organizers :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "End Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Start Date :";
            // 
            // dateEndDate
            // 
            this.dateEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEndDate.Location = new System.Drawing.Point(113, 115);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Size = new System.Drawing.Size(169, 20);
            this.dateEndDate.TabIndex = 9;
            // 
            // dateStartDate
            // 
            this.dateStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStartDate.Location = new System.Drawing.Point(113, 91);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Size = new System.Drawing.Size(169, 20);
            this.dateStartDate.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Date of Training :";
            // 
            // dateTrainingDate
            // 
            this.dateTrainingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTrainingDate.Location = new System.Drawing.Point(113, 38);
            this.dateTrainingDate.Name = "dateTrainingDate";
            this.dateTrainingDate.Size = new System.Drawing.Size(169, 20);
            this.dateTrainingDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Training Type :";
            // 
            // cboTrainingType
            // 
            this.cboTrainingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainingType.FormattingEnabled = true;
            this.cboTrainingType.Location = new System.Drawing.Point(113, 11);
            this.cboTrainingType.Name = "cboTrainingType";
            this.cboTrainingType.Size = new System.Drawing.Size(169, 21);
            this.cboTrainingType.TabIndex = 0;
            this.cboTrainingType.DropDown += new System.EventHandler(this.cboTrainingType_DropDown);
            this.cboTrainingType.SelectedIndexChanged += new System.EventHandler(this.cboTrainingType_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnTrainingAllowanceType);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(1, 585);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 27);
            this.panel2.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(519, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(438, 2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(357, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTrainingAllowanceType
            // 
            this.btnTrainingAllowanceType.Location = new System.Drawing.Point(3, 2);
            this.btnTrainingAllowanceType.Name = "btnTrainingAllowanceType";
            this.btnTrainingAllowanceType.Size = new System.Drawing.Size(84, 23);
            this.btnTrainingAllowanceType.TabIndex = 0;
            this.btnTrainingAllowanceType.Text = "Training Cost";
            this.btnTrainingAllowanceType.UseVisualStyleBackColor = true;
            this.btnTrainingAllowanceType.Click += new System.EventHandler(this.btnTrainingAllowanceType_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(276, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Cost";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Currency";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 180;
            // 
            // TrainingNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 612);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "TrainingNewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrainingNewForm";
            this.Load += new System.EventHandler(this.TrainingNewForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrainingCosts)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox agetxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gendertxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTrainingType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.DateTimePicker dateStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTrainingDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbSponsor;
        private System.Windows.Forms.Button moreButton;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.ComboBox cmbOrganizers;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVenue;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView gridTrainingCosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfDays;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtCertificate;
        private System.Windows.Forms.TextBox cmbProgramme;
        private System.Windows.Forms.Button btnTrainingAllowanceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridTrainingAllowanceType;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCost;
        private System.Windows.Forms.TextBox txtLocationType;
        private System.Windows.Forms.Button btnImage;
    }
}