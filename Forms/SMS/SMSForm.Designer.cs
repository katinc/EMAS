namespace eMAS.Forms.SMS
{
    partial class SMSForm
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
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDenomination = new System.Windows.Forms.Label();
            this.lblReligion = new System.Windows.Forms.Label();
            this.cboDenomination = new System.Windows.Forms.ComboBox();
            this.cboReligion = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.checkBoxSendLater = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePickerScheduleTime = new System.Windows.Forms.DateTimePicker();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblGradeCategory = new System.Windows.Forms.Label();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.staffNoLabel = new System.Windows.Forms.Label();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnView = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "SMS Bulk Messaging";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.lblDenomination);
            this.panel2.Controls.Add(this.lblReligion);
            this.panel2.Controls.Add(this.cboDenomination);
            this.panel2.Controls.Add(this.cboReligion);
            this.panel2.Controls.Add(this.lblGender);
            this.panel2.Controls.Add(this.cboGender);
            this.panel2.Controls.Add(this.checkBoxSendLater);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.dateTimePickerScheduleTime);
            this.panel2.Controls.Add(this.cboGrade);
            this.panel2.Controls.Add(this.lblGrade);
            this.panel2.Controls.Add(this.lblGradeCategory);
            this.panel2.Controls.Add(this.cboGradeCategory);
            this.panel2.Controls.Add(this.cboUnit);
            this.panel2.Controls.Add(this.lblUnit);
            this.panel2.Controls.Add(this.lblDepartment);
            this.panel2.Controls.Add(this.cboDepartment);
            this.panel2.Controls.Add(this.cboZone);
            this.panel2.Controls.Add(this.lblZone);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.staffIDtxt);
            this.panel2.Controls.Add(this.staffNoLabel);
            this.panel2.Controls.Add(this.cmbOption);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nametxt);
            this.panel2.Controls.Add(this.searchGrid);
            this.panel2.Location = new System.Drawing.Point(4, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 258);
            this.panel2.TabIndex = 13;
            // 
            // lblDenomination
            // 
            this.lblDenomination.AutoSize = true;
            this.lblDenomination.Location = new System.Drawing.Point(315, 193);
            this.lblDenomination.Name = "lblDenomination";
            this.lblDenomination.Size = new System.Drawing.Size(75, 13);
            this.lblDenomination.TabIndex = 26;
            this.lblDenomination.Text = "Denomination:";
            this.lblDenomination.Visible = false;
            // 
            // lblReligion
            // 
            this.lblReligion.AutoSize = true;
            this.lblReligion.Location = new System.Drawing.Point(341, 168);
            this.lblReligion.Name = "lblReligion";
            this.lblReligion.Size = new System.Drawing.Size(48, 13);
            this.lblReligion.TabIndex = 25;
            this.lblReligion.Text = "Religion:";
            this.lblReligion.Visible = false;
            // 
            // cboDenomination
            // 
            this.cboDenomination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDenomination.FormattingEnabled = true;
            this.cboDenomination.Location = new System.Drawing.Point(393, 189);
            this.cboDenomination.Name = "cboDenomination";
            this.cboDenomination.Size = new System.Drawing.Size(148, 21);
            this.cboDenomination.TabIndex = 24;
            this.cboDenomination.Visible = false;
            // 
            // cboReligion
            // 
            this.cboReligion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReligion.FormattingEnabled = true;
            this.cboReligion.Location = new System.Drawing.Point(393, 164);
            this.cboReligion.Name = "cboReligion";
            this.cboReligion.Size = new System.Drawing.Size(148, 21);
            this.cboReligion.TabIndex = 23;
            this.cboReligion.Visible = false;
            this.cboReligion.DropDown += new System.EventHandler(this.cboReligion_DropDown);
            this.cboReligion.SelectionChangeCommitted += new System.EventHandler(this.cboReligion_SelectionChangeCommitted);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(344, 141);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 22;
            this.lblGender.Text = "Gender:";
            this.lblGender.Visible = false;
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(393, 137);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(148, 21);
            this.cboGender.TabIndex = 21;
            this.cboGender.Visible = false;
            this.cboGender.DropDown += new System.EventHandler(this.cboGender_DropDown);
            // 
            // checkBoxSendLater
            // 
            this.checkBoxSendLater.AutoSize = true;
            this.checkBoxSendLater.Location = new System.Drawing.Point(93, 216);
            this.checkBoxSendLater.Name = "checkBoxSendLater";
            this.checkBoxSendLater.Size = new System.Drawing.Size(78, 17);
            this.checkBoxSendLater.TabIndex = 20;
            this.checkBoxSendLater.Text = "Send Later";
            this.checkBoxSendLater.UseVisualStyleBackColor = true;
            this.checkBoxSendLater.CheckedChanged += new System.EventHandler(this.checkBoxSendLater_CheckedChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(9, 238);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(81, 13);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Schedule Date:";
            this.lblDate.Visible = false;
            // 
            // dateTimePickerScheduleTime
            // 
            this.dateTimePickerScheduleTime.Checked = false;
            this.dateTimePickerScheduleTime.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerScheduleTime.Location = new System.Drawing.Point(93, 234);
            this.dateTimePickerScheduleTime.Name = "dateTimePickerScheduleTime";
            this.dateTimePickerScheduleTime.ShowCheckBox = true;
            this.dateTimePickerScheduleTime.Size = new System.Drawing.Size(149, 20);
            this.dateTimePickerScheduleTime.TabIndex = 18;
            this.dateTimePickerScheduleTime.Visible = false;
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(393, 111);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(148, 21);
            this.cboGrade.TabIndex = 17;
            this.cboGrade.Visible = false;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblGrade.Location = new System.Drawing.Point(348, 116);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(42, 13);
            this.lblGrade.TabIndex = 16;
            this.lblGrade.Text = "Grade :";
            this.lblGrade.Visible = false;
            // 
            // lblGradeCategory
            // 
            this.lblGradeCategory.AutoSize = true;
            this.lblGradeCategory.Location = new System.Drawing.Point(335, 90);
            this.lblGradeCategory.Name = "lblGradeCategory";
            this.lblGradeCategory.Size = new System.Drawing.Size(55, 13);
            this.lblGradeCategory.TabIndex = 15;
            this.lblGradeCategory.Text = "Category :";
            this.lblGradeCategory.Visible = false;
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(393, 85);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(150, 21);
            this.cboGradeCategory.TabIndex = 14;
            this.cboGradeCategory.Visible = false;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(393, 30);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(148, 21);
            this.cboUnit.TabIndex = 13;
            this.cboUnit.Visible = false;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.Location = new System.Drawing.Point(357, 34);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(32, 13);
            this.lblUnit.TabIndex = 12;
            this.lblUnit.Text = "Unit :";
            this.lblUnit.Visible = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(322, 8);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(68, 13);
            this.lblDepartment.TabIndex = 11;
            this.lblDepartment.Text = "Department :";
            this.lblDepartment.Visible = false;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(393, 4);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(150, 21);
            this.cboDepartment.TabIndex = 9;
            this.cboDepartment.Visible = false;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Items.AddRange(new object[] {
            "Pay Roll",
            "Single Pay Slip",
            "All Pay Slips"});
            this.cboZone.Location = new System.Drawing.Point(393, 58);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(148, 21);
            this.cboZone.TabIndex = 10;
            this.cboZone.Visible = false;
            this.cboZone.DropDown += new System.EventHandler(this.cboZone_DropDown);
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.BackColor = System.Drawing.Color.Transparent;
            this.lblZone.Location = new System.Drawing.Point(351, 63);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(38, 13);
            this.lblZone.TabIndex = 8;
            this.lblZone.Text = "Zone :";
            this.lblZone.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMessage);
            this.groupBox1.Location = new System.Drawing.Point(8, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 123);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Box";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(6, 12);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(278, 104);
            this.txtMessage.TabIndex = 0;
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.staffIDtxt.Location = new System.Drawing.Point(57, 32);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(121, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.Visible = false;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // staffNoLabel
            // 
            this.staffNoLabel.AutoSize = true;
            this.staffNoLabel.BackColor = System.Drawing.Color.Transparent;
            this.staffNoLabel.Location = new System.Drawing.Point(5, 36);
            this.staffNoLabel.Name = "staffNoLabel";
            this.staffNoLabel.Size = new System.Drawing.Size(49, 13);
            this.staffNoLabel.TabIndex = 0;
            this.staffNoLabel.Text = "Staff No:";
            this.staffNoLabel.Visible = false;
            // 
            // cmbOption
            // 
            this.cmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Items.AddRange(new object[] {
            "Pay Roll",
            "Single Pay Slip",
            "All Pay Slips"});
            this.cmbOption.Location = new System.Drawing.Point(57, 9);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(121, 21);
            this.cmbOption.TabIndex = 2;
            this.cmbOption.DropDown += new System.EventHandler(this.cmbOption_DropDown);
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(5, 58);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Option:";
            // 
            // nametxt
            // 
            this.nametxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nametxt.Location = new System.Drawing.Point(57, 54);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(235, 20);
            this.nametxt.TabIndex = 1;
            this.nametxt.Visible = false;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            this.searchGrid.BackgroundColor = System.Drawing.Color.White;
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridStaffNo,
            this.gridName});
            this.searchGrid.Location = new System.Drawing.Point(57, 76);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(274, 83);
            this.searchGrid.TabIndex = 6;
            this.searchGrid.Visible = false;
            this.searchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffsID";
            this.gridStaffNo.HeaderText = "Staff No";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // gridName
            // 
            this.gridName.DataPropertyName = "Name";
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 150;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(185, 292);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 24);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(360, 292);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(298, 292);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 24);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Reset";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(240, 292);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(56, 24);
            this.btnView.TabIndex = 17;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // SMSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(564, 322);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label13);
            this.MaximizeBox = false;
            this.Name = "SMSForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS Form";
            this.Load += new System.EventHandler(this.SMSForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblGradeCategory;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label staffNoLabel;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.CheckBox checkBoxSendLater;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerScheduleTime;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDenomination;
        private System.Windows.Forms.Label lblReligion;
        private System.Windows.Forms.ComboBox cboDenomination;
        private System.Windows.Forms.ComboBox cboReligion;
    }
}