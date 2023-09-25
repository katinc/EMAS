namespace eMAS.Forms.Reports
{
    partial class MedicalClaimsReportMonthlySelect
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMechanised = new System.Windows.Forms.Label();
            this.cboMechanised = new System.Windows.Forms.ComboBox();
            this.txtStaffNo = new System.Windows.Forms.TextBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.periodLabel = new System.Windows.Forms.Label();
            this.staffNoLabel = new System.Windows.Forms.Label();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.label13.Location = new System.Drawing.Point(3, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(257, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Medical Claims Monthly Report Cutomization";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(87, 239);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 24);
            this.btnOK.TabIndex = 27;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(210, 239);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(148, 239);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 24);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.lblMechanised);
            this.panel2.Controls.Add(this.cboMechanised);
            this.panel2.Controls.Add(this.txtStaffNo);
            this.panel2.Controls.Add(this.txtStaffName);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.staffNoLabel);
            this.panel2.Controls.Add(this.cmbOption);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.searchGrid);
            this.panel2.Location = new System.Drawing.Point(6, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 203);
            this.panel2.TabIndex = 24;
            // 
            // lblMechanised
            // 
            this.lblMechanised.AutoSize = true;
            this.lblMechanised.Location = new System.Drawing.Point(6, 36);
            this.lblMechanised.Name = "lblMechanised";
            this.lblMechanised.Size = new System.Drawing.Size(68, 13);
            this.lblMechanised.TabIndex = 37;
            this.lblMechanised.Text = "Mechanised:";
            this.lblMechanised.Visible = false;
            // 
            // cboMechanised
            // 
            this.cboMechanised.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMechanised.FormattingEnabled = true;
            this.cboMechanised.Location = new System.Drawing.Point(76, 32);
            this.cboMechanised.Name = "cboMechanised";
            this.cboMechanised.Size = new System.Drawing.Size(121, 21);
            this.cboMechanised.TabIndex = 36;
            this.cboMechanised.Visible = false;
            this.cboMechanised.SelectedIndexChanged += new System.EventHandler(this.cboMechanised_SelectedIndexChanged);
            // 
            // txtStaffNo
            // 
            this.txtStaffNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffNo.Location = new System.Drawing.Point(76, 54);
            this.txtStaffNo.Name = "txtStaffNo";
            this.txtStaffNo.Size = new System.Drawing.Size(97, 20);
            this.txtStaffNo.TabIndex = 1;
            this.txtStaffNo.Visible = false;
            this.txtStaffNo.TextChanged += new System.EventHandler(this.txtStaffNo_TextChanged);
            // 
            // txtStaffName
            // 
            this.txtStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffName.Location = new System.Drawing.Point(76, 77);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(218, 20);
            this.txtStaffName.TabIndex = 1;
            this.txtStaffName.Visible = false;
            this.txtStaffName.TextChanged += new System.EventHandler(this.txtStaffName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yearComboBox);
            this.groupBox1.Controls.Add(this.monthComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.periodLabel);
            this.groupBox1.Location = new System.Drawing.Point(27, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 74);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attendance Period";
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(49, 46);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(121, 21);
            this.yearComboBox.TabIndex = 2;
            this.yearComboBox.DropDown += new System.EventHandler(this.yearComboBox_DropDown);
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(49, 20);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(121, 21);
            this.monthComboBox.TabIndex = 1;
            this.monthComboBox.DropDown += new System.EventHandler(this.monthComboBox_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(10, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Year:";
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.BackColor = System.Drawing.Color.Transparent;
            this.periodLabel.Location = new System.Drawing.Point(3, 24);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(40, 13);
            this.periodLabel.TabIndex = 0;
            this.periodLabel.Text = "Month:";
            // 
            // staffNoLabel
            // 
            this.staffNoLabel.AutoSize = true;
            this.staffNoLabel.BackColor = System.Drawing.Color.Transparent;
            this.staffNoLabel.Location = new System.Drawing.Point(24, 58);
            this.staffNoLabel.Name = "staffNoLabel";
            this.staffNoLabel.Size = new System.Drawing.Size(49, 13);
            this.staffNoLabel.TabIndex = 0;
            this.staffNoLabel.Text = "Staff No:";
            this.staffNoLabel.Visible = false;
            // 
            // cmbOption
            // 
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Items.AddRange(new object[] {
            "Individual Employee",
            "All Employees"});
            this.cmbOption.Location = new System.Drawing.Point(76, 9);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(121, 21);
            this.cmbOption.TabIndex = 2;
            this.cmbOption.Text = "All Employees";
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(35, 81);
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
            this.label1.Location = new System.Drawing.Point(32, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Option:";
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
            this.searchGrid.Location = new System.Drawing.Point(76, 73);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 112);
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
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // MedicalClaimsReportMonthlySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(358, 265);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "MedicalClaimsReportMonthlySelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medical Claims Monthly Report";
            this.Load += new System.EventHandler(this.medicalClaimsReportSelect_Load);
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
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtStaffNo;
        private System.Windows.Forms.Label staffNoLabel;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Label lblMechanised;
        private System.Windows.Forms.ComboBox cboMechanised;
    }
}