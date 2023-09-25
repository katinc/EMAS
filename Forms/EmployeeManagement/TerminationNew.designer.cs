namespace eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS
{
    partial class TerminationNew
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.findbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridDocuments = new System.Windows.Forms.DataGridView();
            this.gridDocumentsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentsContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cboSeparationType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.employerCheckBox = new System.Windows.Forms.CheckBox();
            this.employeeCheckBox = new System.Windows.Forms.CheckBox();
            this.typecmb = new System.Windows.Forms.ComboBox();
            this.terminationDate = new System.Windows.Forms.DateTimePicker();
            this.reasontxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.filename = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSeparationType = new System.Windows.Forms.TextBox();
            this.txtSeparationDate = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtEmploymentDate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.gradeCategoryTextBox = new System.Windows.Forms.TextBox();
            this.gradeTextBox = new System.Windows.Forms.TextBox();
            this.specialtyTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.departmentTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.agetxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gendertxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.closebtn);
            this.panel2.Controls.Add(this.clearbtn);
            this.panel2.Controls.Add(this.findbtn);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.Location = new System.Drawing.Point(0, 502);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 39);
            this.panel2.TabIndex = 18;
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(455, 8);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(59, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(390, 8);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(59, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // findbtn
            // 
            this.findbtn.Location = new System.Drawing.Point(325, 8);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(59, 23);
            this.findbtn.TabIndex = 1;
            this.findbtn.Text = "View";
            this.findbtn.UseVisualStyleBackColor = true;
            this.findbtn.Click += new System.EventHandler(this.findbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(260, 8);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(59, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(546, 32);
            this.panel3.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(8, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "New Separation";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridDocuments);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.cboSeparationType);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.employerCheckBox);
            this.groupBox2.Controls.Add(this.employeeCheckBox);
            this.groupBox2.Controls.Add(this.typecmb);
            this.groupBox2.Controls.Add(this.terminationDate);
            this.groupBox2.Controls.Add(this.reasontxt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.filename);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 170);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Separation Details";
            // 
            // gridDocuments
            // 
            this.gridDocuments.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.gridDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDocuments.BackgroundColor = System.Drawing.Color.SlateGray;
            this.gridDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridDocumentsID,
            this.gridDocumentsDescription,
            this.gridDocumentsPath,
            this.gridDocumentsDocumentsContent});
            this.gridDocuments.GridColor = System.Drawing.SystemColors.Control;
            this.gridDocuments.Location = new System.Drawing.Point(290, 18);
            this.gridDocuments.Name = "gridDocuments";
            this.gridDocuments.RowHeadersWidth = 23;
            this.gridDocuments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDocuments.Size = new System.Drawing.Size(195, 105);
            this.gridDocuments.TabIndex = 22;
            // 
            // gridDocumentsID
            // 
            this.gridDocumentsID.HeaderText = "ID";
            this.gridDocumentsID.Name = "gridDocumentsID";
            this.gridDocumentsID.Visible = false;
            // 
            // gridDocumentsDescription
            // 
            this.gridDocumentsDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridDocumentsDescription.DataPropertyName = "Description";
            this.gridDocumentsDescription.HeaderText = "Description";
            this.gridDocumentsDescription.Name = "gridDocumentsDescription";
            // 
            // gridDocumentsPath
            // 
            this.gridDocumentsPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridDocumentsPath.FillWeight = 50F;
            this.gridDocumentsPath.HeaderText = "Path";
            this.gridDocumentsPath.Name = "gridDocumentsPath";
            this.gridDocumentsPath.ReadOnly = true;
            this.gridDocumentsPath.Visible = false;
            // 
            // gridDocumentsDocumentsContent
            // 
            this.gridDocumentsDocumentsContent.HeaderText = "DocumentsContent";
            this.gridDocumentsDocumentsContent.Name = "gridDocumentsDocumentsContent";
            this.gridDocumentsDocumentsContent.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(407, 129);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(78, 22);
            this.btnPreview.TabIndex = 19;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(290, 128);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(78, 22);
            this.btnImport.TabIndex = 19;
            this.btnImport.Text = "Attach Letter";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cboSeparationType
            // 
            this.cboSeparationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeparationType.FormattingEnabled = true;
            this.cboSeparationType.Location = new System.Drawing.Point(115, 66);
            this.cboSeparationType.Name = "cboSeparationType";
            this.cboSeparationType.Size = new System.Drawing.Size(169, 21);
            this.cboSeparationType.TabIndex = 18;
            this.cboSeparationType.DropDown += new System.EventHandler(this.cboSeparationType_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Separation Type:";
            // 
            // employerCheckBox
            // 
            this.employerCheckBox.AutoSize = true;
            this.employerCheckBox.Location = new System.Drawing.Point(217, 152);
            this.employerCheckBox.Name = "employerCheckBox";
            this.employerCheckBox.Size = new System.Drawing.Size(15, 14);
            this.employerCheckBox.TabIndex = 16;
            this.employerCheckBox.UseVisualStyleBackColor = true;
            // 
            // employeeCheckBox
            // 
            this.employeeCheckBox.AutoSize = true;
            this.employeeCheckBox.Location = new System.Drawing.Point(217, 128);
            this.employeeCheckBox.Name = "employeeCheckBox";
            this.employeeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.employeeCheckBox.TabIndex = 15;
            this.employeeCheckBox.UseVisualStyleBackColor = true;
            // 
            // typecmb
            // 
            this.typecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typecmb.FormattingEnabled = true;
            this.typecmb.Items.AddRange(new object[] {
            "Employee Instigated",
            "Employer Instigated"});
            this.typecmb.Location = new System.Drawing.Point(115, 42);
            this.typecmb.Name = "typecmb";
            this.typecmb.Size = new System.Drawing.Size(169, 21);
            this.typecmb.TabIndex = 13;
            this.typecmb.DropDown += new System.EventHandler(this.typecmb_DropDown);
            // 
            // terminationDate
            // 
            this.terminationDate.CustomFormat = "dd/MM/yyyy";
            this.terminationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.terminationDate.Location = new System.Drawing.Point(115, 19);
            this.terminationDate.Name = "terminationDate";
            this.terminationDate.ShowCheckBox = true;
            this.terminationDate.Size = new System.Drawing.Size(169, 20);
            this.terminationDate.TabIndex = 14;
            // 
            // reasontxt
            // 
            this.reasontxt.Location = new System.Drawing.Point(114, 92);
            this.reasontxt.Multiline = true;
            this.reasontxt.Name = "reasontxt";
            this.reasontxt.Size = new System.Drawing.Size(170, 31);
            this.reasontxt.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Employer Notified?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Employee Notified?";
            // 
            // filename
            // 
            this.filename.AutoSize = true;
            this.filename.Location = new System.Drawing.Point(260, 69);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(0, 13);
            this.filename.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Reason:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Initiation Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Separation Date:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtSeparationType);
            this.groupBox1.Controls.Add(this.txtSeparationDate);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.txtEmploymentDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.unitTextBox);
            this.groupBox1.Controls.Add(this.gradeCategoryTextBox);
            this.groupBox1.Controls.Add(this.gradeTextBox);
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
            this.groupBox1.Location = new System.Drawing.Point(6, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 286);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Staff";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(88, 237);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 13);
            this.label19.TabIndex = 49;
            this.label19.Text = "Separation Date:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(90, 260);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 13);
            this.label18.TabIndex = 48;
            this.label18.Text = "SeparationType:";
            // 
            // txtSeparationType
            // 
            this.txtSeparationType.Enabled = false;
            this.txtSeparationType.Location = new System.Drawing.Point(178, 256);
            this.txtSeparationType.Name = "txtSeparationType";
            this.txtSeparationType.Size = new System.Drawing.Size(180, 20);
            this.txtSeparationType.TabIndex = 47;
            // 
            // txtSeparationDate
            // 
            this.txtSeparationDate.Enabled = false;
            this.txtSeparationDate.Location = new System.Drawing.Point(178, 233);
            this.txtSeparationDate.Name = "txtSeparationDate";
            this.txtSeparationDate.Size = new System.Drawing.Size(180, 20);
            this.txtSeparationDate.TabIndex = 46;
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
            this.unitTextBox.Location = new System.Drawing.Point(178, 124);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(180, 20);
            this.unitTextBox.TabIndex = 41;
            // 
            // gradeCategoryTextBox
            // 
            this.gradeCategoryTextBox.Enabled = false;
            this.gradeCategoryTextBox.Location = new System.Drawing.Point(178, 146);
            this.gradeCategoryTextBox.Name = "gradeCategoryTextBox";
            this.gradeCategoryTextBox.Size = new System.Drawing.Size(180, 20);
            this.gradeCategoryTextBox.TabIndex = 40;
            // 
            // gradeTextBox
            // 
            this.gradeTextBox.Enabled = false;
            this.gradeTextBox.Location = new System.Drawing.Point(178, 167);
            this.gradeTextBox.Name = "gradeTextBox";
            this.gradeTextBox.Size = new System.Drawing.Size(180, 20);
            this.gradeTextBox.TabIndex = 39;
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
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(178, 33);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(222, 20);
            this.nametxt.TabIndex = 1;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
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
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridName,
            this.gridStaffNo});
            this.searchGrid.Location = new System.Drawing.Point(178, 28);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 252);
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
            // TerminationNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(527, 541);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "TerminationNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Separation";
            this.Load += new System.EventHandler(this.Termination_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button findbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox employerCheckBox;
        private System.Windows.Forms.CheckBox employeeCheckBox;
        private System.Windows.Forms.ComboBox typecmb;
        private System.Windows.Forms.DateTimePicker terminationDate;
        private System.Windows.Forms.TextBox reasontxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox agetxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gendertxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.ComboBox cboSeparationType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox txtEmploymentDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.TextBox gradeCategoryTextBox;
        private System.Windows.Forms.TextBox gradeTextBox;
        private System.Windows.Forms.TextBox specialtyTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox departmentTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtSeparationDate;
        private System.Windows.Forms.TextBox txtSeparationType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label filename;
        private System.Windows.Forms.DataGridView gridDocuments;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentsContent;
    }
}