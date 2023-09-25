
namespace eMAS.Forms.EmployeeManagement
{
    partial class Locum
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
            this.findbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownNumberOfDays = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblExcuseDutySheet = new System.Windows.Forms.Label();
            this.dtpRequestDate = new System.Windows.Forms.DateTimePicker();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreviewSheet = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCurrentGrade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAnnualLeaveYear = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLeaveArrears = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtLeaveDue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.departmentTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.opfDialog = new System.Windows.Forms.OpenFileDialog();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfDays)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // findbtn
            // 
            this.findbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findbtn.Location = new System.Drawing.Point(441, 7);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(70, 23);
            this.findbtn.TabIndex = 1;
            this.findbtn.Text = "View";
            this.findbtn.UseVisualStyleBackColor = true;
            this.findbtn.Click += new System.EventHandler(this.findbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Locum";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.numericUpDownNumberOfDays);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.btnBrowseFile);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.lblExcuseDutySheet);
            this.groupBox1.Controls.Add(this.dtpRequestDate);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.lblReason);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(0, 330);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 171);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request Details";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(93, 106);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(139, 20);
            this.dtpEndDate.TabIndex = 103;
            this.dtpEndDate.Value = new System.DateTime(2021, 9, 23, 0, 0, 0, 0);
            // 
            // numericUpDownNumberOfDays
            // 
            this.numericUpDownNumberOfDays.Location = new System.Drawing.Point(93, 80);
            this.numericUpDownNumberOfDays.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownNumberOfDays.Name = "numericUpDownNumberOfDays";
            this.numericUpDownNumberOfDays.Size = new System.Drawing.Size(139, 20);
            this.numericUpDownNumberOfDays.TabIndex = 102;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(18, 82);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 13);
            this.label23.TabIndex = 106;
            this.label23.Text = "No. of Days:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 106);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 105;
            this.label14.Text = "End Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 104;
            this.label10.Text = "Start Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(93, 54);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(139, 20);
            this.dtpStartDate.TabIndex = 101;
            this.dtpStartDate.Value = new System.DateTime(2021, 9, 23, 0, 0, 0, 0);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFile.Location = new System.Drawing.Point(550, 26);
            this.btnBrowseFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(24, 19);
            this.btnBrowseFile.TabIndex = 4;
            this.btnBrowseFile.Text = "+";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(374, 26);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(172, 20);
            this.txtFileName.TabIndex = 100;
            // 
            // lblExcuseDutySheet
            // 
            this.lblExcuseDutySheet.AutoSize = true;
            this.lblExcuseDutySheet.Location = new System.Drawing.Point(263, 29);
            this.lblExcuseDutySheet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExcuseDutySheet.Name = "lblExcuseDutySheet";
            this.lblExcuseDutySheet.Size = new System.Drawing.Size(100, 13);
            this.lblExcuseDutySheet.TabIndex = 44;
            this.lblExcuseDutySheet.Text = "Locum Application :";
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequestDate.Location = new System.Drawing.Point(93, 28);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.ShowCheckBox = true;
            this.dtpRequestDate.Size = new System.Drawing.Size(139, 20);
            this.dtpRequestDate.TabIndex = 3;
            this.dtpRequestDate.Value = new System.DateTime(2021, 9, 23, 0, 0, 0, 0);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(374, 55);
            this.txtReason.Margin = new System.Windows.Forms.Padding(2);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(200, 90);
            this.txtReason.TabIndex = 8;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(313, 55);
            this.lblReason.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(50, 13);
            this.lblReason.TabIndex = 36;
            this.lblReason.Text = "Reason :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 29);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Request Date:";
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.Location = new System.Drawing.Point(295, 7);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(70, 23);
            this.savebtn.TabIndex = 9;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(720, 40);
            this.panel3.TabIndex = 42;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPreviewSheet);
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.findbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(0, 499);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 40);
            this.panel1.TabIndex = 43;
            // 
            // btnPreviewSheet
            // 
            this.btnPreviewSheet.Location = new System.Drawing.Point(3, 7);
            this.btnPreviewSheet.Name = "btnPreviewSheet";
            this.btnPreviewSheet.Size = new System.Drawing.Size(143, 23);
            this.btnPreviewSheet.TabIndex = 20;
            this.btnPreviewSheet.Text = "Preview Locum Application";
            this.btnPreviewSheet.UseVisualStyleBackColor = true;
            this.btnPreviewSheet.Click += new System.EventHandler(this.btnPreviewSheet_Click);
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.Location = new System.Drawing.Point(514, 7);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(70, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearbtn.Location = new System.Drawing.Point(368, 7);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(70, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.txtCurrentGrade);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPhoneNo);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtAnnualLeaveYear);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtLeaveArrears);
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.txtLeaveDue);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.departmentTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.agetxt);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.gendertxt);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.pictureBox);
            this.groupBox2.Controls.Add(this.staffIDtxt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nametxt);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.searchGrid);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(-1, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 290);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Staff";
            // 
            // txtCurrentGrade
            // 
            this.txtCurrentGrade.BackColor = System.Drawing.Color.White;
            this.txtCurrentGrade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurrentGrade.Enabled = false;
            this.txtCurrentGrade.Location = new System.Drawing.Point(236, 159);
            this.txtCurrentGrade.Name = "txtCurrentGrade";
            this.txtCurrentGrade.ReadOnly = true;
            this.txtCurrentGrade.Size = new System.Drawing.Size(180, 20);
            this.txtCurrentGrade.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Current Grade:";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.BackColor = System.Drawing.Color.White;
            this.txtPhoneNo.Enabled = false;
            this.txtPhoneNo.Location = new System.Drawing.Point(236, 135);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.ReadOnly = true;
            this.txtPhoneNo.Size = new System.Drawing.Size(180, 20);
            this.txtPhoneNo.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(171, 137);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "Phone No.:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(236, 110);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(196, 114);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Email:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(201, 233);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Year:";
            // 
            // txtAnnualLeaveYear
            // 
            this.txtAnnualLeaveYear.Enabled = false;
            this.txtAnnualLeaveYear.Location = new System.Drawing.Point(236, 228);
            this.txtAnnualLeaveYear.Name = "txtAnnualLeaveYear";
            this.txtAnnualLeaveYear.Size = new System.Drawing.Size(100, 20);
            this.txtAnnualLeaveYear.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(157, 254);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Leave Arrears:";
            // 
            // txtLeaveArrears
            // 
            this.txtLeaveArrears.Enabled = false;
            this.txtLeaveArrears.Location = new System.Drawing.Point(236, 250);
            this.txtLeaveArrears.Name = "txtLeaveArrears";
            this.txtLeaveArrears.ReadOnly = true;
            this.txtLeaveArrears.Size = new System.Drawing.Size(181, 20);
            this.txtLeaveArrears.TabIndex = 25;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(29, 175);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(98, 23);
            this.btnView.TabIndex = 24;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            // 
            // txtLeaveDue
            // 
            this.txtLeaveDue.BackColor = System.Drawing.Color.White;
            this.txtLeaveDue.Enabled = false;
            this.txtLeaveDue.Location = new System.Drawing.Point(236, 206);
            this.txtLeaveDue.Name = "txtLeaveDue";
            this.txtLeaveDue.ReadOnly = true;
            this.txtLeaveDue.Size = new System.Drawing.Size(180, 20);
            this.txtLeaveDue.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(156, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Annual Leave:";
            // 
            // departmentTextBox
            // 
            this.departmentTextBox.BackColor = System.Drawing.Color.White;
            this.departmentTextBox.Enabled = false;
            this.departmentTextBox.Location = new System.Drawing.Point(236, 184);
            this.departmentTextBox.Name = "departmentTextBox";
            this.departmentTextBox.ReadOnly = true;
            this.departmentTextBox.Size = new System.Drawing.Size(180, 20);
            this.departmentTextBox.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Department:";
            // 
            // agetxt
            // 
            this.agetxt.BackColor = System.Drawing.Color.White;
            this.agetxt.Enabled = false;
            this.agetxt.Location = new System.Drawing.Point(236, 85);
            this.agetxt.Name = "agetxt";
            this.agetxt.ReadOnly = true;
            this.agetxt.Size = new System.Drawing.Size(180, 20);
            this.agetxt.TabIndex = 100;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(199, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Age:";
            // 
            // gendertxt
            // 
            this.gendertxt.BackColor = System.Drawing.Color.White;
            this.gendertxt.Enabled = false;
            this.gendertxt.Location = new System.Drawing.Point(236, 62);
            this.gendertxt.Name = "gendertxt";
            this.gendertxt.ReadOnly = true;
            this.gendertxt.Size = new System.Drawing.Size(180, 20);
            this.gendertxt.TabIndex = 100;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 65);
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
            this.pictureBox.Location = new System.Drawing.Point(13, 16);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(126, 153);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(236, 16);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(180, 20);
            this.staffIDtxt.TabIndex = 0;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Staff ID:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(236, 39);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(180, 20);
            this.nametxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 42);
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
            this.searchGrid.Location = new System.Drawing.Point(236, 35);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 245);
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
            // opfDialog
            // 
            this.opfDialog.FileName = "openFileDialog1";
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
            // Locum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(590, 539);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Locum";
            this.Text = "Locum";
            this.Load += new System.EventHandler(this.Locum_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfDays)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button findbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblExcuseDutySheet;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPreviewSheet;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCurrentGrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAnnualLeaveYear;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLeaveArrears;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtLeaveDue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox departmentTextBox;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.OpenFileDialog opfDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfDays;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
    }
}