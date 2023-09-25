namespace eMAS.Forms.Notifications
{
    partial class NotificationsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPensionOverdue = new System.Windows.Forms.CheckBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chkProbationOverdue = new System.Windows.Forms.CheckBox();
            this.chkLeaveOverDue = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabNotifications = new System.Windows.Forms.TabControl();
            this.tabLeave = new System.Windows.Forms.TabPage();
            this.chkLeaveNotifyRelatedStaff = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLeaveSMSMessage = new System.Windows.Forms.TextBox();
            this.htmlTextBoxLeaveEmailMessage = new GvS.Controls.HtmlTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLeaveEmailCaption = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabProbation = new System.Windows.Forms.TabPage();
            this.chkProbationNotifyRelatedStaff = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProbationSMSMessage = new System.Windows.Forms.TextBox();
            this.htmlTextBoxProbationEmailMessage = new GvS.Controls.HtmlTextbox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProbationEmailCaption = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPension = new System.Windows.Forms.TabPage();
            this.chkPensionNotifyRelatedStaff = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPensionSMSMessage = new System.Windows.Forms.TextBox();
            this.htmlTextBoxPensionEmailMessage = new GvS.Controls.HtmlTextbox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPensionEmailCaption = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveReceiver = new System.Windows.Forms.Button();
            this.gridNotificationReceivers = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridReceiveSMS = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridEmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridReceiveEmail = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabNotifications.SuspendLayout();
            this.tabLeave.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabProbation.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPension.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotificationReceivers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(866, 38);
            this.panel3.TabIndex = 34;
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
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 513);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 37);
            this.panel1.TabIndex = 35;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(697, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(786, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkPensionOverdue);
            this.panel2.Controls.Add(this.chkIsActive);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Location = new System.Drawing.Point(13, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 42);
            this.panel2.TabIndex = 37;
            // 
            // chkPensionOverdue
            // 
            this.chkPensionOverdue.AutoSize = true;
            this.chkPensionOverdue.Location = new System.Drawing.Point(287, 12);
            this.chkPensionOverdue.Name = "chkPensionOverdue";
            this.chkPensionOverdue.Size = new System.Drawing.Size(108, 17);
            this.chkPensionOverdue.TabIndex = 6;
            this.chkPensionOverdue.Text = "Pension Overdue";
            this.chkPensionOverdue.UseVisualStyleBackColor = true;
            this.chkPensionOverdue.CheckedChanged += new System.EventHandler(this.chkPensionOverdue_CheckedChanged);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(771, 13);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(67, 17);
            this.chkIsActive.TabIndex = 3;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Alert On:";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.chkProbationOverdue);
            this.panel6.Controls.Add(this.chkLeaveOverDue);
            this.panel6.Location = new System.Drawing.Point(55, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(356, 33);
            this.panel6.TabIndex = 7;
            // 
            // chkProbationOverdue
            // 
            this.chkProbationOverdue.AutoSize = true;
            this.chkProbationOverdue.Location = new System.Drawing.Point(114, 7);
            this.chkProbationOverdue.Name = "chkProbationOverdue";
            this.chkProbationOverdue.Size = new System.Drawing.Size(115, 17);
            this.chkProbationOverdue.TabIndex = 5;
            this.chkProbationOverdue.Text = "Probation Overdue";
            this.chkProbationOverdue.UseVisualStyleBackColor = true;
            this.chkProbationOverdue.CheckedChanged += new System.EventHandler(this.chkProbationOverdue_CheckedChanged);
            // 
            // chkLeaveOverDue
            // 
            this.chkLeaveOverDue.AutoSize = true;
            this.chkLeaveOverDue.Checked = true;
            this.chkLeaveOverDue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLeaveOverDue.Location = new System.Drawing.Point(8, 8);
            this.chkLeaveOverDue.Name = "chkLeaveOverDue";
            this.chkLeaveOverDue.Size = new System.Drawing.Size(100, 17);
            this.chkLeaveOverDue.TabIndex = 4;
            this.chkLeaveOverDue.Text = "Leave Overdue";
            this.chkLeaveOverDue.UseVisualStyleBackColor = true;
            this.chkLeaveOverDue.CheckedChanged += new System.EventHandler(this.chkLeaveOverDue_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabNotifications);
            this.groupBox1.Location = new System.Drawing.Point(13, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 239);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Format";
            // 
            // tabNotifications
            // 
            this.tabNotifications.Controls.Add(this.tabLeave);
            this.tabNotifications.Controls.Add(this.tabProbation);
            this.tabNotifications.Controls.Add(this.tabPension);
            this.tabNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabNotifications.Location = new System.Drawing.Point(3, 16);
            this.tabNotifications.Name = "tabNotifications";
            this.tabNotifications.SelectedIndex = 0;
            this.tabNotifications.Size = new System.Drawing.Size(840, 220);
            this.tabNotifications.TabIndex = 37;
            // 
            // tabLeave
            // 
            this.tabLeave.BackColor = System.Drawing.SystemColors.Control;
            this.tabLeave.Controls.Add(this.chkLeaveNotifyRelatedStaff);
            this.tabLeave.Controls.Add(this.label6);
            this.tabLeave.Controls.Add(this.txtLeaveSMSMessage);
            this.tabLeave.Controls.Add(this.htmlTextBoxLeaveEmailMessage);
            this.tabLeave.Controls.Add(this.label4);
            this.tabLeave.Controls.Add(this.panel4);
            this.tabLeave.Controls.Add(this.txtLeaveEmailCaption);
            this.tabLeave.Controls.Add(this.label3);
            this.tabLeave.Location = new System.Drawing.Point(4, 22);
            this.tabLeave.Name = "tabLeave";
            this.tabLeave.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabLeave.Size = new System.Drawing.Size(832, 194);
            this.tabLeave.TabIndex = 0;
            this.tabLeave.Text = "Leave";
            // 
            // chkLeaveNotifyRelatedStaff
            // 
            this.chkLeaveNotifyRelatedStaff.AutoSize = true;
            this.chkLeaveNotifyRelatedStaff.Location = new System.Drawing.Point(713, 20);
            this.chkLeaveNotifyRelatedStaff.Name = "chkLeaveNotifyRelatedStaff";
            this.chkLeaveNotifyRelatedStaff.Size = new System.Drawing.Size(118, 17);
            this.chkLeaveNotifyRelatedStaff.TabIndex = 9;
            this.chkLeaveNotifyRelatedStaff.Text = "Notify Related Staff";
            this.chkLeaveNotifyRelatedStaff.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "SMS Message";
            // 
            // txtLeaveSMSMessage
            // 
            this.txtLeaveSMSMessage.Location = new System.Drawing.Point(443, 54);
            this.txtLeaveSMSMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLeaveSMSMessage.Multiline = true;
            this.txtLeaveSMSMessage.Name = "txtLeaveSMSMessage";
            this.txtLeaveSMSMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLeaveSMSMessage.Size = new System.Drawing.Size(284, 98);
            this.txtLeaveSMSMessage.TabIndex = 7;
            // 
            // htmlTextBoxLeaveEmailMessage
            // 
            this.htmlTextBoxLeaveEmailMessage.Fonts = new string[] {
        "Corbel",
        "Corbel, Verdana, Arial, Helvetica, sans-serif",
        "Georgia, Times New Roman, Times, serif",
        "Consolas, Courier New, Courier, monospace"};
            this.htmlTextBoxLeaveEmailMessage.IllegalPatterns = new string[] {
        "<script.*?>",
        "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>",
        "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>",
        "</?input.*?>"};
            this.htmlTextBoxLeaveEmailMessage.Location = new System.Drawing.Point(4, 54);
            this.htmlTextBoxLeaveEmailMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.htmlTextBoxLeaveEmailMessage.Name = "htmlTextBoxLeaveEmailMessage";
            this.htmlTextBoxLeaveEmailMessage.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.htmlTextBoxLeaveEmailMessage.ShowHtmlSource = false;
            this.htmlTextBoxLeaveEmailMessage.Size = new System.Drawing.Size(400, 101);
            this.htmlTextBoxLeaveEmailMessage.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Email Message";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 163);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(826, 28);
            this.panel4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(9, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(365, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Allowed Tokens:  are : {EventDate} ,{StaffID} and {StaffName}";
            // 
            // txtLeaveEmailCaption
            // 
            this.txtLeaveEmailCaption.Location = new System.Drawing.Point(177, 29);
            this.txtLeaveEmailCaption.Name = "txtLeaveEmailCaption";
            this.txtLeaveEmailCaption.Size = new System.Drawing.Size(228, 20);
            this.txtLeaveEmailCaption.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Email Caption:";
            // 
            // tabProbation
            // 
            this.tabProbation.BackColor = System.Drawing.SystemColors.Control;
            this.tabProbation.Controls.Add(this.chkProbationNotifyRelatedStaff);
            this.tabProbation.Controls.Add(this.label13);
            this.tabProbation.Controls.Add(this.label7);
            this.tabProbation.Controls.Add(this.txtProbationSMSMessage);
            this.tabProbation.Controls.Add(this.htmlTextBoxProbationEmailMessage);
            this.tabProbation.Controls.Add(this.panel5);
            this.tabProbation.Controls.Add(this.txtProbationEmailCaption);
            this.tabProbation.Controls.Add(this.label9);
            this.tabProbation.Location = new System.Drawing.Point(4, 22);
            this.tabProbation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabProbation.Name = "tabProbation";
            this.tabProbation.Size = new System.Drawing.Size(1111, 369);
            this.tabProbation.TabIndex = 1;
            this.tabProbation.Text = "Probation";
            // 
            // chkProbationNotifyRelatedStaff
            // 
            this.chkProbationNotifyRelatedStaff.AutoSize = true;
            this.chkProbationNotifyRelatedStaff.Location = new System.Drawing.Point(716, 14);
            this.chkProbationNotifyRelatedStaff.Name = "chkProbationNotifyRelatedStaff";
            this.chkProbationNotifyRelatedStaff.Size = new System.Drawing.Size(118, 17);
            this.chkProbationNotifyRelatedStaff.TabIndex = 16;
            this.chkProbationNotifyRelatedStaff.Text = "Notify Related Staff";
            this.chkProbationNotifyRelatedStaff.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Email Message";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "SMS Message";
            // 
            // txtProbationSMSMessage
            // 
            this.txtProbationSMSMessage.Location = new System.Drawing.Point(443, 49);
            this.txtProbationSMSMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProbationSMSMessage.Multiline = true;
            this.txtProbationSMSMessage.Name = "txtProbationSMSMessage";
            this.txtProbationSMSMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProbationSMSMessage.Size = new System.Drawing.Size(284, 98);
            this.txtProbationSMSMessage.TabIndex = 13;
            // 
            // htmlTextBoxProbationEmailMessage
            // 
            this.htmlTextBoxProbationEmailMessage.Fonts = new string[] {
        "Corbel",
        "Corbel, Verdana, Arial, Helvetica, sans-serif",
        "Georgia, Times New Roman, Times, serif",
        "Consolas, Courier New, Courier, monospace"};
            this.htmlTextBoxProbationEmailMessage.IllegalPatterns = new string[] {
        "<script.*?>",
        "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>",
        "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>",
        "</?input.*?>"};
            this.htmlTextBoxProbationEmailMessage.Location = new System.Drawing.Point(4, 49);
            this.htmlTextBoxProbationEmailMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.htmlTextBoxProbationEmailMessage.Name = "htmlTextBoxProbationEmailMessage";
            this.htmlTextBoxProbationEmailMessage.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.htmlTextBoxProbationEmailMessage.ShowHtmlSource = false;
            this.htmlTextBoxProbationEmailMessage.Size = new System.Drawing.Size(400, 101);
            this.htmlTextBoxProbationEmailMessage.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(0, 341);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1111, 28);
            this.panel5.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(9, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(365, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Allowed Tokens:  are : {EventDate} ,{StaffID} and {StaffName}";
            // 
            // txtProbationEmailCaption
            // 
            this.txtProbationEmailCaption.Location = new System.Drawing.Point(177, 24);
            this.txtProbationEmailCaption.Name = "txtProbationEmailCaption";
            this.txtProbationEmailCaption.Size = new System.Drawing.Size(228, 20);
            this.txtProbationEmailCaption.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Email Caption:";
            // 
            // tabPension
            // 
            this.tabPension.BackColor = System.Drawing.SystemColors.Control;
            this.tabPension.Controls.Add(this.chkPensionNotifyRelatedStaff);
            this.tabPension.Controls.Add(this.label14);
            this.tabPension.Controls.Add(this.label10);
            this.tabPension.Controls.Add(this.txtPensionSMSMessage);
            this.tabPension.Controls.Add(this.htmlTextBoxPensionEmailMessage);
            this.tabPension.Controls.Add(this.panel7);
            this.tabPension.Controls.Add(this.txtPensionEmailCaption);
            this.tabPension.Controls.Add(this.label12);
            this.tabPension.Location = new System.Drawing.Point(4, 22);
            this.tabPension.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPension.Name = "tabPension";
            this.tabPension.Size = new System.Drawing.Size(1111, 369);
            this.tabPension.TabIndex = 2;
            this.tabPension.Text = "Pension";
            // 
            // chkPensionNotifyRelatedStaff
            // 
            this.chkPensionNotifyRelatedStaff.AutoSize = true;
            this.chkPensionNotifyRelatedStaff.Location = new System.Drawing.Point(713, 15);
            this.chkPensionNotifyRelatedStaff.Name = "chkPensionNotifyRelatedStaff";
            this.chkPensionNotifyRelatedStaff.Size = new System.Drawing.Size(118, 17);
            this.chkPensionNotifyRelatedStaff.TabIndex = 16;
            this.chkPensionNotifyRelatedStaff.Text = "Notify Related Staff";
            this.chkPensionNotifyRelatedStaff.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Email Message";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(441, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "SMS Message";
            // 
            // txtPensionSMSMessage
            // 
            this.txtPensionSMSMessage.Location = new System.Drawing.Point(443, 49);
            this.txtPensionSMSMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPensionSMSMessage.Multiline = true;
            this.txtPensionSMSMessage.Name = "txtPensionSMSMessage";
            this.txtPensionSMSMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPensionSMSMessage.Size = new System.Drawing.Size(284, 98);
            this.txtPensionSMSMessage.TabIndex = 13;
            // 
            // htmlTextBoxPensionEmailMessage
            // 
            this.htmlTextBoxPensionEmailMessage.Fonts = new string[] {
        "Corbel",
        "Corbel, Verdana, Arial, Helvetica, sans-serif",
        "Georgia, Times New Roman, Times, serif",
        "Consolas, Courier New, Courier, monospace"};
            this.htmlTextBoxPensionEmailMessage.IllegalPatterns = new string[] {
        "<script.*?>",
        "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>",
        "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>",
        "</?input.*?>"};
            this.htmlTextBoxPensionEmailMessage.Location = new System.Drawing.Point(4, 49);
            this.htmlTextBoxPensionEmailMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.htmlTextBoxPensionEmailMessage.Name = "htmlTextBoxPensionEmailMessage";
            this.htmlTextBoxPensionEmailMessage.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.htmlTextBoxPensionEmailMessage.ShowHtmlSource = false;
            this.htmlTextBoxPensionEmailMessage.Size = new System.Drawing.Size(400, 101);
            this.htmlTextBoxPensionEmailMessage.TabIndex = 12;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.label11);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(0, 341);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1111, 28);
            this.panel7.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(9, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(365, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Allowed Tokens:  are : {EventDate} ,{StaffID} and {StaffName}";
            // 
            // txtPensionEmailCaption
            // 
            this.txtPensionEmailCaption.Location = new System.Drawing.Point(177, 24);
            this.txtPensionEmailCaption.Name = "txtPensionEmailCaption";
            this.txtPensionEmailCaption.Size = new System.Drawing.Size(228, 20);
            this.txtPensionEmailCaption.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(175, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Email Caption:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveReceiver);
            this.groupBox2.Controls.Add(this.gridNotificationReceivers);
            this.groupBox2.Location = new System.Drawing.Point(13, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(846, 168);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Default Receivers";
            // 
            // btnRemoveReceiver
            // 
            this.btnRemoveReceiver.Location = new System.Drawing.Point(774, 63);
            this.btnRemoveReceiver.Name = "btnRemoveReceiver";
            this.btnRemoveReceiver.Size = new System.Drawing.Size(62, 23);
            this.btnRemoveReceiver.TabIndex = 1;
            this.btnRemoveReceiver.Text = "Remove";
            this.btnRemoveReceiver.UseVisualStyleBackColor = true;
            this.btnRemoveReceiver.Click += new System.EventHandler(this.btnRemoveReceiver_Click);
            // 
            // gridNotificationReceivers
            // 
            this.gridNotificationReceivers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridNotificationReceivers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridNotificationReceivers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridNotificationReceivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridNotificationReceivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridStaffID,
            this.gridStaffName,
            this.gridDepartment,
            this.gridTel,
            this.gridReceiveSMS,
            this.gridEmailAddress,
            this.gridReceiveEmail});
            this.gridNotificationReceivers.Location = new System.Drawing.Point(7, 20);
            this.gridNotificationReceivers.MultiSelect = false;
            this.gridNotificationReceivers.Name = "gridNotificationReceivers";
            this.gridNotificationReceivers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.gridNotificationReceivers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridNotificationReceivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNotificationReceivers.Size = new System.Drawing.Size(761, 141);
            this.gridNotificationReceivers.TabIndex = 0;
            this.gridNotificationReceivers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNotificationReceivers_CellValueChanged);
            // 
            // gridID
            // 
            this.gridID.DataPropertyName = "ID";
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.Visible = false;
            // 
            // gridStaffID
            // 
            this.gridStaffID.DataPropertyName = "StaffID";
            this.gridStaffID.HeaderText = "Staff ID";
            this.gridStaffID.Name = "gridStaffID";
            this.gridStaffID.Width = 110;
            // 
            // gridStaffName
            // 
            this.gridStaffName.DataPropertyName = "StaffName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridStaffName.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridStaffName.HeaderText = "Name";
            this.gridStaffName.Name = "gridStaffName";
            this.gridStaffName.Width = 200;
            // 
            // gridDepartment
            // 
            this.gridDepartment.DataPropertyName = "Department";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridDepartment.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridDepartment.HeaderText = "Department";
            this.gridDepartment.Name = "gridDepartment";
            this.gridDepartment.Width = 200;
            // 
            // gridTel
            // 
            this.gridTel.DataPropertyName = "MobileNo";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridTel.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridTel.HeaderText = "Tel";
            this.gridTel.Name = "gridTel";
            this.gridTel.Width = 120;
            // 
            // gridReceiveSMS
            // 
            this.gridReceiveSMS.DataPropertyName = "GetSMS";
            this.gridReceiveSMS.FalseValue = "0";
            this.gridReceiveSMS.HeaderText = "Get SMS";
            this.gridReceiveSMS.Name = "gridReceiveSMS";
            this.gridReceiveSMS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReceiveSMS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridReceiveSMS.TrueValue = "1";
            // 
            // gridEmailAddress
            // 
            this.gridEmailAddress.DataPropertyName = "Email";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridEmailAddress.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridEmailAddress.HeaderText = "Email Address";
            this.gridEmailAddress.Name = "gridEmailAddress";
            this.gridEmailAddress.Width = 150;
            // 
            // gridReceiveEmail
            // 
            this.gridReceiveEmail.DataPropertyName = "GetEmail";
            this.gridReceiveEmail.FalseValue = "0";
            this.gridReceiveEmail.HeaderText = "Get Email";
            this.gridReceiveEmail.Name = "gridReceiveEmail";
            this.gridReceiveEmail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReceiveEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridReceiveEmail.TrueValue = "1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Staff ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Department";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "Tel";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn5.HeaderText = "Email Address";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // NotificationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 550);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.Name = "NotificationsForm";
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.NotificationsForm_Load);
            this.Shown += new System.EventHandler(this.NotificationsForm_Shown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabNotifications.ResumeLayout(false);
            this.tabLeave.ResumeLayout(false);
            this.tabLeave.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabProbation.ResumeLayout(false);
            this.tabProbation.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPension.ResumeLayout(false);
            this.tabPension.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNotificationReceivers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabNotifications;
        private System.Windows.Forms.TabPage tabLeave;
        private System.Windows.Forms.TextBox txtLeaveEmailCaption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveReceiver;
        private System.Windows.Forms.DataGridView gridNotificationReceivers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkIsActive;
        private GvS.Controls.HtmlTextbox htmlTextBoxLeaveEmailMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.CheckBox chkProbationOverdue;
        private System.Windows.Forms.CheckBox chkLeaveOverDue;
        private System.Windows.Forms.CheckBox chkPensionOverdue;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLeaveSMSMessage;
        private System.Windows.Forms.TabPage tabProbation;
        private System.Windows.Forms.TabPage tabPension;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProbationSMSMessage;
        private GvS.Controls.HtmlTextbox htmlTextBoxProbationEmailMessage;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProbationEmailCaption;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPensionSMSMessage;
        private GvS.Controls.HtmlTextbox htmlTextBoxPensionEmailMessage;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPensionEmailCaption;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkLeaveNotifyRelatedStaff;
        private System.Windows.Forms.CheckBox chkProbationNotifyRelatedStaff;
        private System.Windows.Forms.CheckBox chkPensionNotifyRelatedStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridReceiveSMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEmailAddress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridReceiveEmail;
    }
}