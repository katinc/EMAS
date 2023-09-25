namespace eMAS.Forms.SystemSetup
{
    partial class CompanyInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyInfo));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearbtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.postalAddressTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.emailAddressTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.webSiteTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contactNoTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pensionMaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.numericUpDownPINMinimumCharacter = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinimumCharacter = new System.Windows.Forms.NumericUpDown();
            this.checkBoxIsFileNumber = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cboFacilityType = new System.Windows.Forms.ComboBox();
            this.cboOwnershipType = new System.Windows.Forms.ComboBox();
            this.faxNosTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dateEstablishedPicker = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.townComboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.districtComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.regionComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.mottoTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maximumAgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.minimumAgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pensionfemaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.wageGroupBox = new System.Windows.Forms.GroupBox();
            this.minimumWageNumbericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.wagePaymentUnitComboBox = new System.Windows.Forms.ComboBox();
            this.paymentLabel = new System.Windows.Forms.Label();
            this.wageCheckBox = new System.Windows.Forms.CheckBox();
            this.salaryCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.salaryGroupBox = new System.Windows.Forms.GroupBox();
            this.minimumSalaryNumbericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.salaryPaymentUnitComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.overTimeGroupBox = new System.Windows.Forms.GroupBox();
            this.calculatedOnComboBox = new System.Windows.Forms.ComboBox();
            this.calculatedOnLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.amountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minimumOvertimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.amountLabel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.frequencyComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxIsSalaryStructure = new System.Windows.Forms.CheckBox();
            this.ssnitRegNoTextBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.overTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pensionMaleNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPINMinimumCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinimumCharacter)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumAgeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumAgeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pensionfemaleNumericUpDown)).BeginInit();
            this.wageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumWageNumbericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.salaryGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumSalaryNumbericUpDown)).BeginInit();
            this.overTimeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumOvertimeNumericUpDown)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 44);
            this.panel2.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(-2, 607);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 42);
            this.panel1.TabIndex = 23;
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(596, 6);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(75, 23);
            this.clearbtn.TabIndex = 2;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(674, 6);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(64, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(530, 6);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(64, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Name";
            // 
            // nametextBox
            // 
            this.nametextBox.BackColor = System.Drawing.Color.White;
            this.nametextBox.Location = new System.Drawing.Point(98, 12);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.ReadOnly = true;
            this.nametextBox.Size = new System.Drawing.Size(167, 20);
            this.nametextBox.TabIndex = 26;
            // 
            // postalAddressTextBox
            // 
            this.postalAddressTextBox.Location = new System.Drawing.Point(98, 35);
            this.postalAddressTextBox.Name = "postalAddressTextBox";
            this.postalAddressTextBox.Size = new System.Drawing.Size(167, 20);
            this.postalAddressTextBox.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Postal Address";
            // 
            // emailAddressTextBox
            // 
            this.emailAddressTextBox.Location = new System.Drawing.Point(98, 58);
            this.emailAddressTextBox.Name = "emailAddressTextBox";
            this.emailAddressTextBox.Size = new System.Drawing.Size(167, 20);
            this.emailAddressTextBox.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Email Address";
            // 
            // webSiteTextBox
            // 
            this.webSiteTextBox.Location = new System.Drawing.Point(98, 82);
            this.webSiteTextBox.Name = "webSiteTextBox";
            this.webSiteTextBox.Size = new System.Drawing.Size(167, 20);
            this.webSiteTextBox.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Website";
            // 
            // contactNoTextBox
            // 
            this.contactNoTextBox.Location = new System.Drawing.Point(98, 105);
            this.contactNoTextBox.Name = "contactNoTextBox";
            this.contactNoTextBox.Size = new System.Drawing.Size(167, 20);
            this.contactNoTextBox.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Contact No(s)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Pension Age [Males]";
            // 
            // pensionMaleNumericUpDown
            // 
            this.pensionMaleNumericUpDown.Location = new System.Drawing.Point(443, 25);
            this.pensionMaleNumericUpDown.Name = "pensionMaleNumericUpDown";
            this.pensionMaleNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.pensionMaleNumericUpDown.TabIndex = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.numericUpDownPINMinimumCharacter);
            this.groupBox1.Controls.Add(this.numericUpDownMinimumCharacter);
            this.groupBox1.Controls.Add(this.checkBoxIsFileNumber);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.cboFacilityType);
            this.groupBox1.Controls.Add(this.cboOwnershipType);
            this.groupBox1.Controls.Add(this.faxNosTextBox);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.dateEstablishedPicker);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.townComboBox);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.districtComboBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.regionComboBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.countryComboBox);
            this.groupBox1.Controls.Add(this.mottoTextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nametextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.postalAddressTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.contactNoTextBox);
            this.groupBox1.Controls.Add(this.emailAddressTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.webSiteTextBox);
            this.groupBox1.Location = new System.Drawing.Point(5, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 207);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(189, 184);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(97, 13);
            this.label28.TabIndex = 57;
            this.label28.Text = "MinimumCharacter:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(377, 182);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(115, 13);
            this.label27.TabIndex = 56;
            this.label27.Text = "PINMinimumCharacter:";
            // 
            // numericUpDownPINMinimumCharacter
            // 
            this.numericUpDownPINMinimumCharacter.Location = new System.Drawing.Point(495, 179);
            this.numericUpDownPINMinimumCharacter.Name = "numericUpDownPINMinimumCharacter";
            this.numericUpDownPINMinimumCharacter.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownPINMinimumCharacter.TabIndex = 55;
            // 
            // numericUpDownMinimumCharacter
            // 
            this.numericUpDownMinimumCharacter.Location = new System.Drawing.Point(290, 181);
            this.numericUpDownMinimumCharacter.Name = "numericUpDownMinimumCharacter";
            this.numericUpDownMinimumCharacter.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownMinimumCharacter.TabIndex = 54;
            // 
            // checkBoxIsFileNumber
            // 
            this.checkBoxIsFileNumber.AutoSize = true;
            this.checkBoxIsFileNumber.Location = new System.Drawing.Point(98, 181);
            this.checkBoxIsFileNumber.Name = "checkBoxIsFileNumber";
            this.checkBoxIsFileNumber.Size = new System.Drawing.Size(93, 17);
            this.checkBoxIsFileNumber.TabIndex = 53;
            this.checkBoxIsFileNumber.Text = "Is File Number";
            this.checkBoxIsFileNumber.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(16, 157);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 13);
            this.label26.TabIndex = 52;
            this.label26.Text = "Facility Type";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(298, 157);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 13);
            this.label25.TabIndex = 51;
            this.label25.Text = "Ownership Type";
            // 
            // cboFacilityType
            // 
            this.cboFacilityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFacilityType.FormattingEnabled = true;
            this.cboFacilityType.Location = new System.Drawing.Point(98, 154);
            this.cboFacilityType.Name = "cboFacilityType";
            this.cboFacilityType.Size = new System.Drawing.Size(167, 21);
            this.cboFacilityType.TabIndex = 50;
            this.cboFacilityType.DropDown += new System.EventHandler(this.cboFacilityType_DropDown);
            // 
            // cboOwnershipType
            // 
            this.cboOwnershipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOwnershipType.FormattingEnabled = true;
            this.cboOwnershipType.Location = new System.Drawing.Point(387, 152);
            this.cboOwnershipType.Name = "cboOwnershipType";
            this.cboOwnershipType.Size = new System.Drawing.Size(167, 21);
            this.cboOwnershipType.TabIndex = 49;
            this.cboOwnershipType.DropDown += new System.EventHandler(this.cboOwnershipType_DropDown);
            // 
            // faxNosTextBox
            // 
            this.faxNosTextBox.Location = new System.Drawing.Point(98, 129);
            this.faxNosTextBox.Name = "faxNosTextBox";
            this.faxNosTextBox.Size = new System.Drawing.Size(167, 20);
            this.faxNosTextBox.TabIndex = 48;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 133);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 47;
            this.label19.Text = "Fax No(s)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(297, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 13);
            this.label18.TabIndex = 46;
            this.label18.Text = "Date Established";
            // 
            // dateEstablishedPicker
            // 
            this.dateEstablishedPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEstablishedPicker.Location = new System.Drawing.Point(387, 104);
            this.dateEstablishedPicker.Name = "dateEstablishedPicker";
            this.dateEstablishedPicker.Size = new System.Drawing.Size(167, 20);
            this.dateEstablishedPicker.TabIndex = 45;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(297, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "Town";
            // 
            // townComboBox
            // 
            this.townComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.townComboBox.FormattingEnabled = true;
            this.townComboBox.Location = new System.Drawing.Point(387, 81);
            this.townComboBox.Name = "townComboBox";
            this.townComboBox.Size = new System.Drawing.Size(167, 21);
            this.townComboBox.TabIndex = 43;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(297, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "District";
            // 
            // districtComboBox
            // 
            this.districtComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.districtComboBox.FormattingEnabled = true;
            this.districtComboBox.Location = new System.Drawing.Point(387, 57);
            this.districtComboBox.Name = "districtComboBox";
            this.districtComboBox.Size = new System.Drawing.Size(167, 21);
            this.districtComboBox.TabIndex = 41;
            this.districtComboBox.SelectionChangeCommitted += new System.EventHandler(this.districtComboBox_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(297, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Region";
            // 
            // regionComboBox
            // 
            this.regionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionComboBox.FormattingEnabled = true;
            this.regionComboBox.Location = new System.Drawing.Point(387, 34);
            this.regionComboBox.Name = "regionComboBox";
            this.regionComboBox.Size = new System.Drawing.Size(167, 21);
            this.regionComboBox.TabIndex = 39;
            this.regionComboBox.SelectionChangeCommitted += new System.EventHandler(this.regionComboBox_SelectionChangeCommitted);
            this.regionComboBox.DropDown += new System.EventHandler(this.regionComboBox_DropDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(297, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Country";
            // 
            // countryComboBox
            // 
            this.countryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(387, 11);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(167, 21);
            this.countryComboBox.TabIndex = 37;
            this.countryComboBox.DropDown += new System.EventHandler(this.countryComboBox_DropDown);
            // 
            // mottoTextBox
            // 
            this.mottoTextBox.Location = new System.Drawing.Point(387, 127);
            this.mottoTextBox.Name = "mottoTextBox";
            this.mottoTextBox.Size = new System.Drawing.Size(167, 20);
            this.mottoTextBox.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(297, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Motto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maximumAgeNumericUpDown);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.minimumAgeNumericUpDown);
            this.groupBox2.Controls.Add(this.pensionfemaleNumericUpDown);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.pensionMaleNumericUpDown);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(5, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 68);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee Age Boundaries ";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // maximumAgeNumericUpDown
            // 
            this.maximumAgeNumericUpDown.Location = new System.Drawing.Point(255, 25);
            this.maximumAgeNumericUpDown.Name = "maximumAgeNumericUpDown";
            this.maximumAgeNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.maximumAgeNumericUpDown.TabIndex = 61;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(183, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 13);
            this.label22.TabIndex = 60;
            this.label22.Text = "Maximum Age";
            // 
            // minimumAgeNumericUpDown
            // 
            this.minimumAgeNumericUpDown.Location = new System.Drawing.Point(98, 26);
            this.minimumAgeNumericUpDown.Name = "minimumAgeNumericUpDown";
            this.minimumAgeNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.minimumAgeNumericUpDown.TabIndex = 59;
            // 
            // pensionfemaleNumericUpDown
            // 
            this.pensionfemaleNumericUpDown.Location = new System.Drawing.Point(642, 25);
            this.pensionfemaleNumericUpDown.Name = "pensionfemaleNumericUpDown";
            this.pensionfemaleNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.pensionfemaleNumericUpDown.TabIndex = 38;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(22, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 13);
            this.label21.TabIndex = 52;
            this.label21.Text = "Minimum Age";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(526, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Pension Age [Females]";
            // 
            // wageGroupBox
            // 
            this.wageGroupBox.Controls.Add(this.minimumWageNumbericUpDown);
            this.wageGroupBox.Controls.Add(this.label12);
            this.wageGroupBox.Controls.Add(this.wagePaymentUnitComboBox);
            this.wageGroupBox.Controls.Add(this.paymentLabel);
            this.wageGroupBox.Location = new System.Drawing.Point(259, 63);
            this.wageGroupBox.Name = "wageGroupBox";
            this.wageGroupBox.Size = new System.Drawing.Size(256, 81);
            this.wageGroupBox.TabIndex = 40;
            this.wageGroupBox.TabStop = false;
            this.wageGroupBox.Visible = false;
            // 
            // minimumWageNumbericUpDown
            // 
            this.minimumWageNumbericUpDown.Location = new System.Drawing.Point(133, 21);
            this.minimumWageNumbericUpDown.Name = "minimumWageNumbericUpDown";
            this.minimumWageNumbericUpDown.Size = new System.Drawing.Size(72, 20);
            this.minimumWageNumbericUpDown.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Minimum Wage";
            // 
            // wagePaymentUnitComboBox
            // 
            this.wagePaymentUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wagePaymentUnitComboBox.FormattingEnabled = true;
            this.wagePaymentUnitComboBox.Location = new System.Drawing.Point(133, 47);
            this.wagePaymentUnitComboBox.Name = "wagePaymentUnitComboBox";
            this.wagePaymentUnitComboBox.Size = new System.Drawing.Size(72, 21);
            this.wagePaymentUnitComboBox.TabIndex = 44;
            this.wagePaymentUnitComboBox.DropDown += new System.EventHandler(this.paymentUnitComboBox_DropDown);
            // 
            // paymentLabel
            // 
            this.paymentLabel.AutoSize = true;
            this.paymentLabel.Location = new System.Drawing.Point(14, 52);
            this.paymentLabel.Name = "paymentLabel";
            this.paymentLabel.Size = new System.Drawing.Size(70, 13);
            this.paymentLabel.TabIndex = 43;
            this.paymentLabel.Text = "Payment Unit";
            // 
            // wageCheckBox
            // 
            this.wageCheckBox.AutoSize = true;
            this.wageCheckBox.Location = new System.Drawing.Point(259, 45);
            this.wageCheckBox.Name = "wageCheckBox";
            this.wageCheckBox.Size = new System.Drawing.Size(125, 17);
            this.wageCheckBox.TabIndex = 46;
            this.wageCheckBox.Text = "Wage Compensation";
            this.wageCheckBox.UseVisualStyleBackColor = true;
            this.wageCheckBox.CheckedChanged += new System.EventHandler(this.wageCheckBox_CheckedChanged);
            // 
            // salaryCheckBox
            // 
            this.salaryCheckBox.AutoSize = true;
            this.salaryCheckBox.Location = new System.Drawing.Point(11, 44);
            this.salaryCheckBox.Name = "salaryCheckBox";
            this.salaryCheckBox.Size = new System.Drawing.Size(125, 17);
            this.salaryCheckBox.TabIndex = 45;
            this.salaryCheckBox.Text = "Salary Compensation";
            this.salaryCheckBox.UseVisualStyleBackColor = true;
            this.salaryCheckBox.CheckedChanged += new System.EventHandler(this.salaryCheckBox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnView);
            this.groupBox4.Controls.Add(this.btnUpload);
            this.groupBox4.Controls.Add(this.pictureBox);
            this.groupBox4.Location = new System.Drawing.Point(587, 69);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(151, 173);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Logo";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(76, 151);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(56, 23);
            this.btnView.TabIndex = 40;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(4, 151);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(55, 23);
            this.btnUpload.TabIndex = 38;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::eMAS.Properties.Resources._default;
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(5, 23);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(127, 124);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 39;
            this.pictureBox.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // salaryGroupBox
            // 
            this.salaryGroupBox.Controls.Add(this.minimumSalaryNumbericUpDown);
            this.salaryGroupBox.Controls.Add(this.label10);
            this.salaryGroupBox.Controls.Add(this.salaryPaymentUnitComboBox);
            this.salaryGroupBox.Controls.Add(this.label11);
            this.salaryGroupBox.Location = new System.Drawing.Point(11, 63);
            this.salaryGroupBox.Name = "salaryGroupBox";
            this.salaryGroupBox.Size = new System.Drawing.Size(193, 81);
            this.salaryGroupBox.TabIndex = 48;
            this.salaryGroupBox.TabStop = false;
            this.salaryGroupBox.Visible = false;
            // 
            // minimumSalaryNumbericUpDown
            // 
            this.minimumSalaryNumbericUpDown.Location = new System.Drawing.Point(102, 21);
            this.minimumSalaryNumbericUpDown.Name = "minimumSalaryNumbericUpDown";
            this.minimumSalaryNumbericUpDown.Size = new System.Drawing.Size(57, 20);
            this.minimumSalaryNumbericUpDown.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Minimum Salary";
            // 
            // salaryPaymentUnitComboBox
            // 
            this.salaryPaymentUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.salaryPaymentUnitComboBox.FormattingEnabled = true;
            this.salaryPaymentUnitComboBox.Location = new System.Drawing.Point(102, 47);
            this.salaryPaymentUnitComboBox.Name = "salaryPaymentUnitComboBox";
            this.salaryPaymentUnitComboBox.Size = new System.Drawing.Size(57, 21);
            this.salaryPaymentUnitComboBox.TabIndex = 44;
            this.salaryPaymentUnitComboBox.DropDown += new System.EventHandler(this.salaryPaymentUnitComboBox_DropDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Payment Unit";
            // 
            // overTimeGroupBox
            // 
            this.overTimeGroupBox.Controls.Add(this.calculatedOnComboBox);
            this.overTimeGroupBox.Controls.Add(this.calculatedOnLabel);
            this.overTimeGroupBox.Controls.Add(this.typeComboBox);
            this.overTimeGroupBox.Controls.Add(this.label20);
            this.overTimeGroupBox.Controls.Add(this.percentageLabel);
            this.overTimeGroupBox.Controls.Add(this.amountNumericUpDown);
            this.overTimeGroupBox.Controls.Add(this.minimumOvertimeNumericUpDown);
            this.overTimeGroupBox.Controls.Add(this.amountLabel);
            this.overTimeGroupBox.Controls.Add(this.label23);
            this.overTimeGroupBox.Location = new System.Drawing.Point(5, 520);
            this.overTimeGroupBox.Name = "overTimeGroupBox";
            this.overTimeGroupBox.Size = new System.Drawing.Size(739, 65);
            this.overTimeGroupBox.TabIndex = 49;
            this.overTimeGroupBox.TabStop = false;
            this.overTimeGroupBox.Visible = false;
            // 
            // calculatedOnComboBox
            // 
            this.calculatedOnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calculatedOnComboBox.FormattingEnabled = true;
            this.calculatedOnComboBox.Location = new System.Drawing.Point(374, 30);
            this.calculatedOnComboBox.Name = "calculatedOnComboBox";
            this.calculatedOnComboBox.Size = new System.Drawing.Size(141, 21);
            this.calculatedOnComboBox.TabIndex = 58;
            this.calculatedOnComboBox.Visible = false;
            this.calculatedOnComboBox.DropDown += new System.EventHandler(this.calculatedOnComboBox_DropDown);
            // 
            // calculatedOnLabel
            // 
            this.calculatedOnLabel.AutoSize = true;
            this.calculatedOnLabel.Location = new System.Drawing.Point(297, 34);
            this.calculatedOnLabel.Name = "calculatedOnLabel";
            this.calculatedOnLabel.Size = new System.Drawing.Size(74, 13);
            this.calculatedOnLabel.TabIndex = 57;
            this.calculatedOnLabel.Text = "Calculated On";
            this.calculatedOnLabel.Visible = false;
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(573, 30);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(141, 21);
            this.typeComboBox.TabIndex = 49;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);
            this.typeComboBox.DropDown += new System.EventHandler(this.typeComboBox_DropDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(533, 33);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "Type";
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageLabel.Location = new System.Drawing.Point(273, 34);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(16, 13);
            this.percentageLabel.TabIndex = 56;
            this.percentageLabel.Text = "%";
            this.percentageLabel.Visible = false;
            // 
            // amountNumericUpDown
            // 
            this.amountNumericUpDown.Location = new System.Drawing.Point(201, 31);
            this.amountNumericUpDown.Name = "amountNumericUpDown";
            this.amountNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.amountNumericUpDown.TabIndex = 51;
            // 
            // minimumOvertimeNumericUpDown
            // 
            this.minimumOvertimeNumericUpDown.Location = new System.Drawing.Point(68, 31);
            this.minimumOvertimeNumericUpDown.Name = "minimumOvertimeNumericUpDown";
            this.minimumOvertimeNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.minimumOvertimeNumericUpDown.TabIndex = 48;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(156, 33);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(43, 13);
            this.amountLabel.TabIndex = 50;
            this.amountLabel.Text = "Amount";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(14, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "Minimum";
            // 
            // frequencyComboBox
            // 
            this.frequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frequencyComboBox.FormattingEnabled = true;
            this.frequencyComboBox.Location = new System.Drawing.Point(573, 54);
            this.frequencyComboBox.Name = "frequencyComboBox";
            this.frequencyComboBox.Size = new System.Drawing.Size(141, 21);
            this.frequencyComboBox.TabIndex = 51;
            this.frequencyComboBox.DropDown += new System.EventHandler(this.frequencyComboBox_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(570, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Payment Frequency";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxIsSalaryStructure);
            this.groupBox5.Controls.Add(this.ssnitRegNoTextBox);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.salaryGroupBox);
            this.groupBox5.Controls.Add(this.frequencyComboBox);
            this.groupBox5.Controls.Add(this.salaryCheckBox);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.wageGroupBox);
            this.groupBox5.Controls.Add(this.wageCheckBox);
            this.groupBox5.Location = new System.Drawing.Point(5, 340);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(739, 151);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Compensation";
            // 
            // checkBoxIsSalaryStructure
            // 
            this.checkBoxIsSalaryStructure.AutoSize = true;
            this.checkBoxIsSalaryStructure.Location = new System.Drawing.Point(11, 19);
            this.checkBoxIsSalaryStructure.Name = "checkBoxIsSalaryStructure";
            this.checkBoxIsSalaryStructure.Size = new System.Drawing.Size(106, 17);
            this.checkBoxIsSalaryStructure.TabIndex = 54;
            this.checkBoxIsSalaryStructure.Text = "IsSalaryStructure";
            this.checkBoxIsSalaryStructure.UseVisualStyleBackColor = true;
            // 
            // ssnitRegNoTextBox
            // 
            this.ssnitRegNoTextBox.Location = new System.Drawing.Point(573, 115);
            this.ssnitRegNoTextBox.Name = "ssnitRegNoTextBox";
            this.ssnitRegNoTextBox.Size = new System.Drawing.Size(141, 20);
            this.ssnitRegNoTextBox.TabIndex = 53;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(570, 95);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(115, 13);
            this.label24.TabIndex = 52;
            this.label24.Text = "SSNIT Registration No";
            // 
            // overTimeCheckBox
            // 
            this.overTimeCheckBox.AutoSize = true;
            this.overTimeCheckBox.Location = new System.Drawing.Point(5, 502);
            this.overTimeCheckBox.Name = "overTimeCheckBox";
            this.overTimeCheckBox.Size = new System.Drawing.Size(75, 17);
            this.overTimeCheckBox.TabIndex = 52;
            this.overTimeCheckBox.Text = "Over Time";
            this.overTimeCheckBox.UseVisualStyleBackColor = true;
            this.overTimeCheckBox.CheckedChanged += new System.EventHandler(this.overTimeCheckBox_CheckedChanged);
            // 
            // CompanyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(750, 646);
            this.Controls.Add(this.overTimeCheckBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.overTimeGroupBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CompanyInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompanyInfo";
            this.Load += new System.EventHandler(this.CompanyInfo_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pensionMaleNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPINMinimumCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinimumCharacter)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumAgeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumAgeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pensionfemaleNumericUpDown)).EndInit();
            this.wageGroupBox.ResumeLayout(false);
            this.wageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumWageNumbericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.salaryGroupBox.ResumeLayout(false);
            this.salaryGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumSalaryNumbericUpDown)).EndInit();
            this.overTimeGroupBox.ResumeLayout(false);
            this.overTimeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumOvertimeNumericUpDown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.TextBox postalAddressTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailAddressTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox webSiteTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox contactNoTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown pensionMaleNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown pensionfemaleNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox wageGroupBox;
        private System.Windows.Forms.CheckBox salaryCheckBox;
        private System.Windows.Forms.ComboBox wagePaymentUnitComboBox;
        private System.Windows.Forms.Label paymentLabel;
        private System.Windows.Forms.CheckBox wageCheckBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.TextBox mottoTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateEstablishedPicker;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox townComboBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox districtComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox regionComboBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown minimumWageNumbericUpDown;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox salaryGroupBox;
        private System.Windows.Forms.NumericUpDown minimumSalaryNumbericUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox salaryPaymentUnitComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox faxNosTextBox;
        private System.Windows.Forms.GroupBox overTimeGroupBox;
        private System.Windows.Forms.NumericUpDown amountNumericUpDown;
        private System.Windows.Forms.NumericUpDown minimumOvertimeNumericUpDown;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox frequencyComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label percentageLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox overTimeCheckBox;
        private System.Windows.Forms.ComboBox calculatedOnComboBox;
        private System.Windows.Forms.Label calculatedOnLabel;
        private System.Windows.Forms.NumericUpDown minimumAgeNumericUpDown;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown maximumAgeNumericUpDown;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox ssnitRegNoTextBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cboFacilityType;
        private System.Windows.Forms.ComboBox cboOwnershipType;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.CheckBox checkBoxIsFileNumber;
        private System.Windows.Forms.CheckBox checkBoxIsSalaryStructure;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numericUpDownPINMinimumCharacter;
        private System.Windows.Forms.NumericUpDown numericUpDownMinimumCharacter;
        private System.Windows.Forms.Button btnView;
    }
}