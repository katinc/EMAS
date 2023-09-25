namespace eMAS.Forms.EmployeeManagement
{
    partial class LeaveRequest
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
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtProgramme = new System.Windows.Forms.TextBox();
            this.lblProgramme = new System.Windows.Forms.Label();
            this.txtInstitution = new System.Windows.Forms.TextBox();
            this.lblInstitution = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.leaveDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfDays = new System.Windows.Forms.NumericUpDown();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.leaveTypecmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.findbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtAnnualEndDate = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtProposedDays = new System.Windows.Forms.TextBox();
            this.txtProposedEndDate = new System.Windows.Forms.TextBox();
            this.txtProposedStartDate = new System.Windows.Forms.TextBox();
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
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPreviewLetter = new System.Windows.Forms.Button();
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
            // endDate
            // 
            this.endDate.CustomFormat = "dd/MM/yyyy";
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(348, 34);
            this.endDate.Name = "endDate";
            this.endDate.ShowCheckBox = true;
            this.endDate.Size = new System.Drawing.Size(124, 20);
            this.endDate.TabIndex = 27;
            this.endDate.Value = new System.DateTime(2014, 9, 26, 0, 0, 0, 0);
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "dd/MM/yyyy";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(348, 11);
            this.startDate.Name = "startDate";
            this.startDate.ShowCheckBox = true;
            this.startDate.Size = new System.Drawing.Size(124, 20);
            this.startDate.TabIndex = 28;
            this.startDate.Value = new System.DateTime(2014, 9, 27, 0, 0, 0, 0);
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(290, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "End Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Start Date:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.lblDuration);
            this.groupBox1.Controls.Add(this.txtDuration);
            this.groupBox1.Controls.Add(this.txtProgramme);
            this.groupBox1.Controls.Add(this.lblProgramme);
            this.groupBox1.Controls.Add(this.txtInstitution);
            this.groupBox1.Controls.Add(this.lblInstitution);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.leaveDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numericUpDownNumberOfDays);
            this.groupBox1.Controls.Add(this.statusTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.leaveTypecmb);
            this.groupBox1.Controls.Add(this.startDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.endDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(12, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 135);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request Details";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(299, 113);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 42;
            this.label19.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(349, 103);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(166, 31);
            this.txtReason.TabIndex = 41;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(27, 107);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 40;
            this.lblDuration.Text = "Duration:";
            this.lblDuration.Visible = false;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(80, 104);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(137, 20);
            this.txtDuration.TabIndex = 39;
            this.txtDuration.Visible = false;
            // 
            // txtProgramme
            // 
            this.txtProgramme.Location = new System.Drawing.Point(80, 82);
            this.txtProgramme.Name = "txtProgramme";
            this.txtProgramme.Size = new System.Drawing.Size(173, 20);
            this.txtProgramme.TabIndex = 38;
            this.txtProgramme.Visible = false;
            // 
            // lblProgramme
            // 
            this.lblProgramme.AutoSize = true;
            this.lblProgramme.Location = new System.Drawing.Point(14, 85);
            this.lblProgramme.Name = "lblProgramme";
            this.lblProgramme.Size = new System.Drawing.Size(63, 13);
            this.lblProgramme.TabIndex = 37;
            this.lblProgramme.Text = "Programme:";
            this.lblProgramme.Visible = false;
            // 
            // txtInstitution
            // 
            this.txtInstitution.Location = new System.Drawing.Point(80, 60);
            this.txtInstitution.Name = "txtInstitution";
            this.txtInstitution.Size = new System.Drawing.Size(173, 20);
            this.txtInstitution.TabIndex = 36;
            this.txtInstitution.Visible = false;
            this.txtInstitution.WordWrap = false;
            // 
            // lblInstitution
            // 
            this.lblInstitution.AutoSize = true;
            this.lblInstitution.Location = new System.Drawing.Point(22, 64);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(55, 13);
            this.lblInstitution.TabIndex = 35;
            this.lblInstitution.Text = "Institution:";
            this.lblInstitution.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(256, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Leave Entry Date:";
            // 
            // leaveDate
            // 
            this.leaveDate.CustomFormat = "dd/MM/yyyy";
            this.leaveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.leaveDate.Location = new System.Drawing.Point(349, 57);
            this.leaveDate.Name = "leaveDate";
            this.leaveDate.ShowCheckBox = true;
            this.leaveDate.Size = new System.Drawing.Size(123, 20);
            this.leaveDate.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(261, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "No. Of Days:";
            // 
            // numericUpDownNumberOfDays
            // 
            this.numericUpDownNumberOfDays.Location = new System.Drawing.Point(349, 80);
            this.numericUpDownNumberOfDays.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownNumberOfDays.Name = "numericUpDownNumberOfDays";
            this.numericUpDownNumberOfDays.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownNumberOfDays.TabIndex = 31;
            this.numericUpDownNumberOfDays.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownNumberOfDays_KeyUp);
            // 
            // statusTextBox
            // 
            this.statusTextBox.BackColor = System.Drawing.Color.White;
            this.statusTextBox.Location = new System.Drawing.Point(80, 37);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(173, 20);
            this.statusTextBox.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Status:";
            // 
            // leaveTypecmb
            // 
            this.leaveTypecmb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.leaveTypecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leaveTypecmb.FormattingEnabled = true;
            this.leaveTypecmb.Items.AddRange(new object[] {
            "Sick Leave",
            "Study Leave",
            "Maternity Leave"});
            this.leaveTypecmb.Location = new System.Drawing.Point(80, 13);
            this.leaveTypecmb.Name = "leaveTypecmb";
            this.leaveTypecmb.Size = new System.Drawing.Size(173, 21);
            this.leaveTypecmb.TabIndex = 29;
            this.leaveTypecmb.SelectionChangeCommitted += new System.EventHandler(this.leaveTypecmb_SelectionChangeCommitted);
            this.leaveTypecmb.DropDown += new System.EventHandler(this.leaveTypecmb_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Type:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(547, 38);
            this.panel3.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Leave Request";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPreviewLetter);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.findbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(0, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 35);
            this.panel1.TabIndex = 35;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(128, 5);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(115, 23);
            this.btnPreview.TabIndex = 37;
            this.btnPreview.Text = "Preview Leave Form";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Visible = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(461, 5);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(67, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(317, 5);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(67, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // findbtn
            // 
            this.findbtn.Location = new System.Drawing.Point(390, 5);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(67, 23);
            this.findbtn.TabIndex = 1;
            this.findbtn.Text = "View";
            this.findbtn.UseVisualStyleBackColor = true;
            this.findbtn.Click += new System.EventHandler(this.findbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(245, 5);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(67, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtAnnualEndDate);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtProposedDays);
            this.groupBox2.Controls.Add(this.txtProposedEndDate);
            this.groupBox2.Controls.Add(this.txtProposedStartDate);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 297);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Staff";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(121, 202);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "Annual End Date:";
            // 
            // txtAnnualEndDate
            // 
            this.txtAnnualEndDate.Location = new System.Drawing.Point(215, 198);
            this.txtAnnualEndDate.Name = "txtAnnualEndDate";
            this.txtAnnualEndDate.ReadOnly = true;
            this.txtAnnualEndDate.Size = new System.Drawing.Size(182, 20);
            this.txtAnnualEndDate.TabIndex = 35;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(131, 271);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "Proposed Days:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(110, 248);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Proposed End Date:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(107, 226);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Proposed Start Date:";
            // 
            // txtProposedDays
            // 
            this.txtProposedDays.Location = new System.Drawing.Point(216, 266);
            this.txtProposedDays.Name = "txtProposedDays";
            this.txtProposedDays.ReadOnly = true;
            this.txtProposedDays.Size = new System.Drawing.Size(100, 20);
            this.txtProposedDays.TabIndex = 31;
            // 
            // txtProposedEndDate
            // 
            this.txtProposedEndDate.Location = new System.Drawing.Point(216, 243);
            this.txtProposedEndDate.Name = "txtProposedEndDate";
            this.txtProposedEndDate.ReadOnly = true;
            this.txtProposedEndDate.Size = new System.Drawing.Size(181, 20);
            this.txtProposedEndDate.TabIndex = 30;
            // 
            // txtProposedStartDate
            // 
            this.txtProposedStartDate.Location = new System.Drawing.Point(216, 221);
            this.txtProposedStartDate.Name = "txtProposedStartDate";
            this.txtProposedStartDate.ReadOnly = true;
            this.txtProposedStartDate.Size = new System.Drawing.Size(181, 20);
            this.txtProposedStartDate.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(180, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Year:";
            // 
            // txtAnnualLeaveYear
            // 
            this.txtAnnualLeaveYear.Enabled = false;
            this.txtAnnualLeaveYear.Location = new System.Drawing.Point(215, 153);
            this.txtAnnualLeaveYear.Name = "txtAnnualLeaveYear";
            this.txtAnnualLeaveYear.Size = new System.Drawing.Size(100, 20);
            this.txtAnnualLeaveYear.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(136, 178);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Leave Arrears:";
            // 
            // txtLeaveArrears
            // 
            this.txtLeaveArrears.Enabled = false;
            this.txtLeaveArrears.Location = new System.Drawing.Point(215, 175);
            this.txtLeaveArrears.Name = "txtLeaveArrears";
            this.txtLeaveArrears.ReadOnly = true;
            this.txtLeaveArrears.Size = new System.Drawing.Size(181, 20);
            this.txtLeaveArrears.TabIndex = 25;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(23, 139);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 24;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtLeaveDue
            // 
            this.txtLeaveDue.BackColor = System.Drawing.Color.White;
            this.txtLeaveDue.Enabled = false;
            this.txtLeaveDue.Location = new System.Drawing.Point(215, 131);
            this.txtLeaveDue.Name = "txtLeaveDue";
            this.txtLeaveDue.ReadOnly = true;
            this.txtLeaveDue.Size = new System.Drawing.Size(180, 20);
            this.txtLeaveDue.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Annual Leave:";
            // 
            // departmentTextBox
            // 
            this.departmentTextBox.BackColor = System.Drawing.Color.White;
            this.departmentTextBox.Enabled = false;
            this.departmentTextBox.Location = new System.Drawing.Point(215, 108);
            this.departmentTextBox.Name = "departmentTextBox";
            this.departmentTextBox.ReadOnly = true;
            this.departmentTextBox.Size = new System.Drawing.Size(180, 20);
            this.departmentTextBox.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Department:";
            // 
            // agetxt
            // 
            this.agetxt.BackColor = System.Drawing.Color.White;
            this.agetxt.Enabled = false;
            this.agetxt.Location = new System.Drawing.Point(215, 85);
            this.agetxt.Name = "agetxt";
            this.agetxt.ReadOnly = true;
            this.agetxt.Size = new System.Drawing.Size(180, 20);
            this.agetxt.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(178, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Age:";
            // 
            // gendertxt
            // 
            this.gendertxt.BackColor = System.Drawing.Color.White;
            this.gendertxt.Enabled = false;
            this.gendertxt.Location = new System.Drawing.Point(215, 62);
            this.gendertxt.Name = "gendertxt";
            this.gendertxt.ReadOnly = true;
            this.gendertxt.Size = new System.Drawing.Size(180, 20);
            this.gendertxt.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 65);
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
            this.pictureBox.Size = new System.Drawing.Size(106, 117);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(215, 16);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(180, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Staff ID:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(215, 39);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(180, 20);
            this.nametxt.TabIndex = 1;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 42);
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
            this.searchGrid.Location = new System.Drawing.Point(215, 35);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 256);
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
            // btnPreviewLetter
            // 
            this.btnPreviewLetter.Location = new System.Drawing.Point(2, 5);
            this.btnPreviewLetter.Name = "btnPreviewLetter";
            this.btnPreviewLetter.Size = new System.Drawing.Size(124, 23);
            this.btnPreviewLetter.TabIndex = 38;
            this.btnPreviewLetter.Text = "Preview Leave Letter";
            this.btnPreviewLetter.UseVisualStyleBackColor = true;
            this.btnPreviewLetter.Visible = false;
            this.btnPreviewLetter.Click += new System.EventHandler(this.btnPreviewLetter_Click);
            // 
            // LeaveRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(536, 517);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Name = "LeaveRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave";
            this.Load += new System.EventHandler(this.Leave_Load);
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

        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox leaveTypecmb;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button findbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.TextBox departmentTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox txtLeaveDue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfDays;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLeaveArrears;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker leaveDate;
        private System.Windows.Forms.TextBox txtAnnualLeaveYear;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtProposedDays;
        private System.Windows.Forms.TextBox txtProposedEndDate;
        private System.Windows.Forms.TextBox txtProposedStartDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtInstitution;
        private System.Windows.Forms.Label lblInstitution;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtProgramme;
        private System.Windows.Forms.Label lblProgramme;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtAnnualEndDate;
        private System.Windows.Forms.Button btnPreviewLetter;
    }
}