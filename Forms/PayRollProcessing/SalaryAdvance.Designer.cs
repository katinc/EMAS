
namespace eMAS.Forms.PayRollProcessing
{
    partial class SalaryAdvance
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
            this.clearbtn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.findbtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.txtMonthlyDeduction = new System.Windows.Forms.TextBox();
            this.lblProgramme = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMonths = new System.Windows.Forms.TextBox();
            this.lblInstitution = new System.Windows.Forms.Label();
            this.dateLoanOrAdvance = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.amountErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(353, 3);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(67, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(136, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Basic Salary:";
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Enabled = false;
            this.txtBasicSalary.Location = new System.Drawing.Point(215, 134);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.ReadOnly = true;
            this.txtBasicSalary.Size = new System.Drawing.Size(181, 20);
            this.txtBasicSalary.TabIndex = 25;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(23, 139);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 24;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnPreView_Click);
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(497, 3);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(67, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
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
            this.searchGrid.Size = new System.Drawing.Size(258, 127);
            this.searchGrid.TabIndex = 19;
            this.searchGrid.Visible = false;
            this.searchGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
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
            // findbtn
            // 
            this.findbtn.Location = new System.Drawing.Point(426, 3);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(67, 23);
            this.findbtn.TabIndex = 1;
            this.findbtn.Text = "View";
            this.findbtn.UseVisualStyleBackColor = true;
            this.findbtn.Click += new System.EventHandler(this.findbtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.ForeColor = System.Drawing.Color.SlateGray;
            this.panel3.Location = new System.Drawing.Point(1, -3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(592, 38);
            this.panel3.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salary Advance";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.numericUpDownAmount);
            this.groupBox1.Controls.Add(this.txtMonthlyDeduction);
            this.groupBox1.Controls.Add(this.lblProgramme);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtMonths);
            this.groupBox1.Controls.Add(this.lblInstitution);
            this.groupBox1.Controls.Add(this.dateLoanOrAdvance);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(1, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 162);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Details";
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.DecimalPlaces = 2;
            this.numericUpDownAmount.Location = new System.Drawing.Point(70, 19);
            this.numericUpDownAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(170, 20);
            this.numericUpDownAmount.TabIndex = 39;
            this.numericUpDownAmount.Tag = "numericupdown";
            this.numericUpDownAmount.ThousandsSeparator = true;
            this.numericUpDownAmount.ValueChanged += new System.EventHandler(this.numericUpDownAmount_ValueChanged);
            // 
            // txtMonthlyDeduction
            // 
            this.txtMonthlyDeduction.Location = new System.Drawing.Point(392, 87);
            this.txtMonthlyDeduction.Name = "txtMonthlyDeduction";
            this.txtMonthlyDeduction.ReadOnly = true;
            this.txtMonthlyDeduction.Size = new System.Drawing.Size(173, 20);
            this.txtMonthlyDeduction.TabIndex = 38;
            // 
            // lblProgramme
            // 
            this.lblProgramme.AutoSize = true;
            this.lblProgramme.Location = new System.Drawing.Point(290, 90);
            this.lblProgramme.Name = "lblProgramme";
            this.lblProgramme.Size = new System.Drawing.Size(99, 13);
            this.lblProgramme.TabIndex = 37;
            this.lblProgramme.Text = "Monthly Deduction:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dateTo);
            this.groupBox3.Controls.Add(this.dateFrom);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(21, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 81);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payment Pariod";
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(48, 44);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(171, 20);
            this.dateTo.TabIndex = 1;
            this.dateTo.ValueChanged += new System.EventHandler(this.dateTo_ValueChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(48, 18);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(171, 20);
            this.dateFrom.TabIndex = 0;
            this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(10, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "From:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(19, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "To:";
            // 
            // txtMonths
            // 
            this.txtMonths.Location = new System.Drawing.Point(392, 65);
            this.txtMonths.Name = "txtMonths";
            this.txtMonths.ReadOnly = true;
            this.txtMonths.Size = new System.Drawing.Size(173, 20);
            this.txtMonths.TabIndex = 36;
            this.txtMonths.WordWrap = false;
            // 
            // lblInstitution
            // 
            this.lblInstitution.AutoSize = true;
            this.lblInstitution.Location = new System.Drawing.Point(275, 68);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(114, 13);
            this.lblInstitution.TabIndex = 35;
            this.lblInstitution.Text = "Spread Over (Months):";
            // 
            // dateLoanOrAdvance
            // 
            this.dateLoanOrAdvance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateLoanOrAdvance.Location = new System.Drawing.Point(395, 19);
            this.dateLoanOrAdvance.Name = "dateLoanOrAdvance";
            this.dateLoanOrAdvance.Size = new System.Drawing.Size(170, 20);
            this.dateLoanOrAdvance.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(329, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Loan Date:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtBasicSalary);
            this.groupBox2.Controls.Add(this.btnView);
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
            this.groupBox2.Location = new System.Drawing.Point(1, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 179);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Staff";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(281, 3);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(67, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.findbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(1, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 38);
            this.panel1.TabIndex = 39;
            // 
            // amountErrorProvider
            // 
            this.amountErrorProvider.ContainerControl = this;
            // 
            // dateErrorProvider
            // 
            this.dateErrorProvider.ContainerControl = this;
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
            // SalaryAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(601, 425);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SalaryAdvance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SalaryAdvance";
            this.Load += new System.EventHandler(this.SalaryAdvance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.amountErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMonthlyDeduction;
        private System.Windows.Forms.Label lblProgramme;
        private System.Windows.Forms.TextBox txtMonths;
        private System.Windows.Forms.Label lblInstitution;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button findbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateLoanOrAdvance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.ErrorProvider amountErrorProvider;
        private System.Windows.Forms.ErrorProvider dateErrorProvider;
    }
}