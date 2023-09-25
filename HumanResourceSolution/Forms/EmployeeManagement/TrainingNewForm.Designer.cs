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
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.cboSponsor = new System.Windows.Forms.ComboBox();
            this.cboLocationType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboTransportationCurrency = new System.Windows.Forms.ComboBox();
            this.cboAccomodationCurrency = new System.Windows.Forms.ComboBox();
            this.cboCostCurrency = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTransportationFee = new System.Windows.Forms.TextBox();
            this.txtAccomodationFee = new System.Windows.Forms.TextBox();
            this.txtCostFee = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCertificateAwarded = new System.Windows.Forms.TextBox();
            this.txtOrganisers = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVenue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTrainingDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboIST = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTrainingType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(602, 30);
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
            this.staffIDtxt.Location = new System.Drawing.Point(180, 35);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(143, 20);
            this.staffIDtxt.TabIndex = 23;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Staff ID:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(180, 13);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(143, 20);
            this.nametxt.TabIndex = 22;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 16);
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
            this.searchGrid.Location = new System.Drawing.Point(180, 29);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 101);
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
            this.groupBox2.Controls.Add(this.cboCourse);
            this.groupBox2.Controls.Add(this.cboSponsor);
            this.groupBox2.Controls.Add(this.cboLocationType);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtCertificateAwarded);
            this.groupBox2.Controls.Add(this.txtOrganisers);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtVenue);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dateEndDate);
            this.groupBox2.Controls.Add(this.dateStartDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dateTrainingDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboIST);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboTrainingType);
            this.groupBox2.Location = new System.Drawing.Point(3, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 225);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Training Details";
            // 
            // cboCourse
            // 
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(112, 55);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(170, 21);
            this.cboCourse.TabIndex = 27;
            // 
            // cboSponsor
            // 
            this.cboSponsor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSponsor.FormattingEnabled = true;
            this.cboSponsor.Location = new System.Drawing.Point(414, 103);
            this.cboSponsor.Name = "cboSponsor";
            this.cboSponsor.Size = new System.Drawing.Size(169, 21);
            this.cboSponsor.TabIndex = 26;
            this.cboSponsor.DropDown += new System.EventHandler(this.cboSponsor_DropDown);
            // 
            // cboLocationType
            // 
            this.cboLocationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocationType.FormattingEnabled = true;
            this.cboLocationType.Location = new System.Drawing.Point(414, 126);
            this.cboLocationType.Name = "cboLocationType";
            this.cboLocationType.Size = new System.Drawing.Size(169, 21);
            this.cboLocationType.TabIndex = 25;
            this.cboLocationType.DropDown += new System.EventHandler(this.cboLocationType_DropDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(330, 127);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "Location Type :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(358, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Sponsor :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.cboTransportationCurrency);
            this.groupBox3.Controls.Add(this.cboAccomodationCurrency);
            this.groupBox3.Controls.Add(this.cboCostCurrency);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtTransportationFee);
            this.groupBox3.Controls.Add(this.txtAccomodationFee);
            this.groupBox3.Controls.Add(this.txtCostFee);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(6, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 100);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cost Covers";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(223, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "Currency";
            // 
            // cboTransportationCurrency
            // 
            this.cboTransportationCurrency.FormattingEnabled = true;
            this.cboTransportationCurrency.Location = new System.Drawing.Point(219, 75);
            this.cboTransportationCurrency.Name = "cboTransportationCurrency";
            this.cboTransportationCurrency.Size = new System.Drawing.Size(48, 21);
            this.cboTransportationCurrency.TabIndex = 23;
            // 
            // cboAccomodationCurrency
            // 
            this.cboAccomodationCurrency.FormattingEnabled = true;
            this.cboAccomodationCurrency.Location = new System.Drawing.Point(219, 54);
            this.cboAccomodationCurrency.Name = "cboAccomodationCurrency";
            this.cboAccomodationCurrency.Size = new System.Drawing.Size(48, 21);
            this.cboAccomodationCurrency.TabIndex = 22;
            // 
            // cboCostCurrency
            // 
            this.cboCostCurrency.FormattingEnabled = true;
            this.cboCostCurrency.Location = new System.Drawing.Point(219, 30);
            this.cboCostCurrency.Name = "cboCostCurrency";
            this.cboCostCurrency.Size = new System.Drawing.Size(48, 21);
            this.cboCostCurrency.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Transportation :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "Accomodation :";
            // 
            // txtTransportationFee
            // 
            this.txtTransportationFee.Location = new System.Drawing.Point(106, 73);
            this.txtTransportationFee.Name = "txtTransportationFee";
            this.txtTransportationFee.Size = new System.Drawing.Size(93, 20);
            this.txtTransportationFee.TabIndex = 18;
            // 
            // txtAccomodationFee
            // 
            this.txtAccomodationFee.Location = new System.Drawing.Point(106, 51);
            this.txtAccomodationFee.Name = "txtAccomodationFee";
            this.txtAccomodationFee.Size = new System.Drawing.Size(93, 20);
            this.txtAccomodationFee.TabIndex = 17;
            // 
            // txtCostFee
            // 
            this.txtCostFee.Location = new System.Drawing.Point(106, 30);
            this.txtCostFee.Name = "txtCostFee";
            this.txtCostFee.Size = new System.Drawing.Size(93, 20);
            this.txtCostFee.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(67, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Cost :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(348, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Organizers :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Certificate Awarded :";
            // 
            // txtCertificateAwarded
            // 
            this.txtCertificateAwarded.Location = new System.Drawing.Point(113, 99);
            this.txtCertificateAwarded.Name = "txtCertificateAwarded";
            this.txtCertificateAwarded.Size = new System.Drawing.Size(201, 20);
            this.txtCertificateAwarded.TabIndex = 17;
            // 
            // txtOrganisers
            // 
            this.txtOrganisers.Location = new System.Drawing.Point(414, 57);
            this.txtOrganisers.Name = "txtOrganisers";
            this.txtOrganisers.Size = new System.Drawing.Size(169, 20);
            this.txtOrganisers.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(367, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Venue :";
            // 
            // txtVenue
            // 
            this.txtVenue.Location = new System.Drawing.Point(414, 35);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.Size = new System.Drawing.Size(169, 20);
            this.txtVenue.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "End Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Start Date :";
            // 
            // dateEndDate
            // 
            this.dateEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEndDate.Location = new System.Drawing.Point(414, 78);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Size = new System.Drawing.Size(169, 20);
            this.dateEndDate.TabIndex = 9;
            // 
            // dateStartDate
            // 
            this.dateStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStartDate.Location = new System.Drawing.Point(113, 77);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Size = new System.Drawing.Size(169, 20);
            this.dateStartDate.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Course :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Date of Training :";
            // 
            // dateTrainingDate
            // 
            this.dateTrainingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTrainingDate.Location = new System.Drawing.Point(113, 34);
            this.dateTrainingDate.Name = "dateTrainingDate";
            this.dateTrainingDate.Size = new System.Drawing.Size(169, 20);
            this.dateTrainingDate.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "IST:";
            // 
            // cboIST
            // 
            this.cboIST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIST.FormattingEnabled = true;
            this.cboIST.Location = new System.Drawing.Point(414, 12);
            this.cboIST.Name = "cboIST";
            this.cboIST.Size = new System.Drawing.Size(168, 21);
            this.cboIST.TabIndex = 2;
            this.cboIST.DropDown += new System.EventHandler(this.cboIST_DropDown);
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
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(1, 412);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 27);
            this.panel2.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(385, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(289, 2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(179, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(75, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // TrainingNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 439);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVenue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.DateTimePicker dateStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTrainingDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboIST;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCertificateAwarded;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCostFee;
        private System.Windows.Forms.TextBox txtOrganisers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTransportationFee;
        private System.Windows.Forms.TextBox txtAccomodationFee;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboLocationType;
        private System.Windows.Forms.ComboBox cboSponsor;
        private System.Windows.Forms.Button moreButton;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.ComboBox cboCostCurrency;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboTransportationCurrency;
        private System.Windows.Forms.ComboBox cboAccomodationCurrency;
        private System.Windows.Forms.ComboBox cboCourse;
    }
}