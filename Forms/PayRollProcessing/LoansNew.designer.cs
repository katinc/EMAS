namespace eMAS.Forms.PayRollProcessing
{
    partial class Loans
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtStaffNo = new System.Windows.Forms.TextBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtLoanOrAdvanceAmount = new System.Windows.Forms.TextBox();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateLoanOrAdvance = new System.Windows.Forms.DateTimePicker();
            this.txtAmountToBePaid = new System.Windows.Forms.TextBox();
            this.txtInterest = new System.Windows.Forms.TextBox();
            this.txtMonthlyInstallment = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.dateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtLoanDescription = new System.Windows.Forms.TextBox();
            this.txtSpreadOver = new System.Windows.Forms.TextBox();
            this.interestErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.amountErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtLoanType = new System.Windows.Forms.ComboBox();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interestErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(471, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(404, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(61, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(271, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Staff No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Staff Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loan Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(12, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Interest Rate (%):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(293, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Spread Over (Months):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(9, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "From:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(165, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "To:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(293, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Monthly Installment:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(293, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Interest:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(291, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Amount To Be Paid:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(293, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Loan Date:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(12, 153);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Loan Amount:";
            // 
            // txtStaffNo
            // 
            this.txtStaffNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffNo.Location = new System.Drawing.Point(108, 56);
            this.txtStaffNo.Name = "txtStaffNo";
            this.txtStaffNo.Size = new System.Drawing.Size(121, 20);
            this.txtStaffNo.TabIndex = 0;
            this.txtStaffNo.TextChanged += new System.EventHandler(this.txtStaffNo_TextChanged);
            // 
            // txtStaffName
            // 
            this.txtStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStaffName.Location = new System.Drawing.Point(108, 79);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(155, 20);
            this.txtStaffName.TabIndex = 1;
            this.txtStaffName.TextChanged += new System.EventHandler(this.txtStaffName_TextChanged);
            // 
            // txtLoanOrAdvanceAmount
            // 
            this.txtLoanOrAdvanceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoanOrAdvanceAmount.Location = new System.Drawing.Point(108, 150);
            this.txtLoanOrAdvanceAmount.Name = "txtLoanOrAdvanceAmount";
            this.txtLoanOrAdvanceAmount.Size = new System.Drawing.Size(121, 20);
            this.txtLoanOrAdvanceAmount.TabIndex = 4;
            this.txtLoanOrAdvanceAmount.TextChanged += new System.EventHandler(this.txtLoanOrAdvanceAmount_TextChanged);
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInterestRate.Location = new System.Drawing.Point(108, 173);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(121, 20);
            this.txtInterestRate.TabIndex = 5;
            this.txtInterestRate.TextChanged += new System.EventHandler(this.txtInterestRate_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dateTo);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(12, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 48);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Pariod";
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(194, 18);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(107, 20);
            this.dateTo.TabIndex = 1;
            this.dateTo.ValueChanged += new System.EventHandler(this.dateTo_ValueChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(48, 18);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(107, 20);
            this.dateFrom.TabIndex = 0;
            this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // dateLoanOrAdvance
            // 
            this.dateLoanOrAdvance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateLoanOrAdvance.Location = new System.Drawing.Point(407, 147);
            this.dateLoanOrAdvance.Name = "dateLoanOrAdvance";
            this.dateLoanOrAdvance.Size = new System.Drawing.Size(107, 20);
            this.dateLoanOrAdvance.TabIndex = 13;
            // 
            // txtAmountToBePaid
            // 
            this.txtAmountToBePaid.BackColor = System.Drawing.Color.White;
            this.txtAmountToBePaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountToBePaid.Location = new System.Drawing.Point(407, 124);
            this.txtAmountToBePaid.Name = "txtAmountToBePaid";
            this.txtAmountToBePaid.ReadOnly = true;
            this.txtAmountToBePaid.Size = new System.Drawing.Size(107, 20);
            this.txtAmountToBePaid.TabIndex = 14;
            // 
            // txtInterest
            // 
            this.txtInterest.BackColor = System.Drawing.Color.White;
            this.txtInterest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInterest.Location = new System.Drawing.Point(407, 101);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.ReadOnly = true;
            this.txtInterest.Size = new System.Drawing.Size(107, 20);
            this.txtInterest.TabIndex = 14;
            // 
            // txtMonthlyInstallment
            // 
            this.txtMonthlyInstallment.BackColor = System.Drawing.Color.White;
            this.txtMonthlyInstallment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonthlyInstallment.Location = new System.Drawing.Point(407, 78);
            this.txtMonthlyInstallment.Name = "txtMonthlyInstallment";
            this.txtMonthlyInstallment.ReadOnly = true;
            this.txtMonthlyInstallment.Size = new System.Drawing.Size(107, 20);
            this.txtMonthlyInstallment.TabIndex = 14;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.ColumnHeadersVisible = false;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridName,
            this.gridStaffNo,
            this.gridStaffCode});
            this.grid.Location = new System.Drawing.Point(108, 72);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 5;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(253, 105);
            this.grid.TabIndex = 17;
            this.grid.Visible = false;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStaffSearch_CellClick);
            // 
            // gridName
            // 
            this.gridName.DataPropertyName = "Name";
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 150;
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffsID";
            this.gridStaffNo.HeaderText = "Staff No";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // gridStaffCode
            // 
            this.gridStaffCode.HeaderText = "StaffCode";
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.ReadOnly = true;
            this.gridStaffCode.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(-7, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 34);
            this.panel1.TabIndex = 18;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(338, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(61, 23);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(-7, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 33);
            this.panel2.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Staff Loans";
            // 
            // dateErrorProvider
            // 
            this.dateErrorProvider.ContainerControl = this;
            // 
            // txtLoanDescription
            // 
            this.txtLoanDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoanDescription.Location = new System.Drawing.Point(108, 101);
            this.txtLoanDescription.Name = "txtLoanDescription";
            this.txtLoanDescription.Size = new System.Drawing.Size(121, 20);
            this.txtLoanDescription.TabIndex = 20;
            // 
            // txtSpreadOver
            // 
            this.txtSpreadOver.BackColor = System.Drawing.Color.White;
            this.txtSpreadOver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpreadOver.Location = new System.Drawing.Point(407, 52);
            this.txtSpreadOver.Name = "txtSpreadOver";
            this.txtSpreadOver.ReadOnly = true;
            this.txtSpreadOver.Size = new System.Drawing.Size(107, 20);
            this.txtSpreadOver.TabIndex = 6;
            // 
            // interestErrorProvider
            // 
            this.interestErrorProvider.ContainerControl = this;
            // 
            // amountErrorProvider
            // 
            this.amountErrorProvider.ContainerControl = this;
            // 
            // txtLoanType
            // 
            this.txtLoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtLoanType.FormattingEnabled = true;
            this.txtLoanType.Location = new System.Drawing.Point(108, 124);
            this.txtLoanType.Name = "txtLoanType";
            this.txtLoanType.Size = new System.Drawing.Size(121, 21);
            this.txtLoanType.TabIndex = 21;
            this.txtLoanType.DropDown += new System.EventHandler(this.txtLoanType_DropDown);
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
            this.dataGridViewTextBoxColumn1.Width = 150;
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
            this.dataGridViewTextBoxColumn3.HeaderText = "StaffCode";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // Loans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(537, 293);
            this.ControlBox = false;
            this.Controls.Add(this.txtLoanType);
            this.Controls.Add(this.txtLoanDescription);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateLoanOrAdvance);
            this.Controls.Add(this.txtMonthlyInstallment);
            this.Controls.Add(this.txtInterest);
            this.Controls.Add(this.txtAmountToBePaid);
            this.Controls.Add(this.txtSpreadOver);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.txtLoanOrAdvanceAmount);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.txtStaffNo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Loans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loans";
            this.Load += new System.EventHandler(this.Loans_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interestErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtStaffNo;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TextBox txtLoanOrAdvanceAmount;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateLoanOrAdvance;
        private System.Windows.Forms.TextBox txtAmountToBePaid;
        private System.Windows.Forms.TextBox txtInterest;
        private System.Windows.Forms.TextBox txtMonthlyInstallment;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider dateErrorProvider;
        private System.Windows.Forms.TextBox txtLoanDescription;
        private System.Windows.Forms.TextBox txtSpreadOver;
        private System.Windows.Forms.ErrorProvider interestErrorProvider;
        private System.Windows.Forms.ErrorProvider amountErrorProvider;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox txtLoanType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
    }
}