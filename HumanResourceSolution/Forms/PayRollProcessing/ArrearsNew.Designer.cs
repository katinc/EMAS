namespace eMAS.Forms.PayRollProcessing
{
    partial class ArrearsNew
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPreView = new System.Windows.Forms.Button();
            this.agetxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gendertxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfTimes = new System.Windows.Forms.NumericUpDown();
            this.lblCurSalary = new System.Windows.Forms.Label();
            this.numericUpDownCurrentSalary = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.inUseCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datePickerEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxIncomeTax = new System.Windows.Forms.CheckBox();
            this.checkBoxSSNIT = new System.Windows.Forms.CheckBox();
            this.lblPrevSalary = new System.Windows.Forms.Label();
            this.numericUpDownPreviousSalary = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.findbtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviousSalary)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(-1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 31);
            this.panel2.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "New Arrears Information";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPreView);
            this.groupBox3.Controls.Add(this.agetxt);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.gendertxt);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.pictureBox);
            this.groupBox3.Controls.Add(this.staffIDtxt);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nametxt);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.searchGrid);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(21, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 167);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Staff";
            // 
            // btnPreView
            // 
            this.btnPreView.Location = new System.Drawing.Point(19, 138);
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.Size = new System.Drawing.Size(75, 23);
            this.btnPreView.TabIndex = 20;
            this.btnPreView.Text = "View";
            this.btnPreView.UseVisualStyleBackColor = true;
            this.btnPreView.Click += new System.EventHandler(this.btnPreView_Click);
            // 
            // agetxt
            // 
            this.agetxt.BackColor = System.Drawing.Color.White;
            this.agetxt.Location = new System.Drawing.Point(204, 86);
            this.agetxt.Name = "agetxt";
            this.agetxt.ReadOnly = true;
            this.agetxt.Size = new System.Drawing.Size(143, 20);
            this.agetxt.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Age:";
            // 
            // gendertxt
            // 
            this.gendertxt.BackColor = System.Drawing.Color.White;
            this.gendertxt.Location = new System.Drawing.Point(204, 63);
            this.gendertxt.Name = "gendertxt";
            this.gendertxt.ReadOnly = true;
            this.gendertxt.Size = new System.Drawing.Size(143, 20);
            this.gendertxt.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Gender:";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::eMAS.Properties.Resources._default;
            this.pictureBox.InitialImage = global::eMAS.Properties.Resources._default;
            this.pictureBox.Location = new System.Drawing.Point(9, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(109, 117);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(204, 16);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(143, 20);
            this.staffIDtxt.TabIndex = 1;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            this.staffIDtxt.Leave += new System.EventHandler(this.staffIDtxt_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Staff ID:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(204, 40);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(198, 20);
            this.nametxt.TabIndex = 1;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            this.nametxt.Leave += new System.EventHandler(this.nametxt_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name:";
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.searchGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.searchGrid.BackgroundColor = System.Drawing.Color.White;
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridName,
            this.gridStaffNo});
            this.searchGrid.Location = new System.Drawing.Point(204, 35);
            this.searchGrid.MultiSelect = false;
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 101);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDownNumberOfTimes);
            this.groupBox1.Controls.Add(this.lblCurSalary);
            this.groupBox1.Controls.Add(this.numericUpDownCurrentSalary);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.inUseCheckBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.datePickerEffectiveDate);
            this.groupBox1.Controls.Add(this.checkBoxIncomeTax);
            this.groupBox1.Controls.Add(this.checkBoxSSNIT);
            this.groupBox1.Controls.Add(this.lblPrevSalary);
            this.groupBox1.Controls.Add(this.numericUpDownPreviousSalary);
            this.groupBox1.Location = new System.Drawing.Point(21, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 139);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Details";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(73, 18);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(115, 21);
            this.cboType.TabIndex = 14;
            this.cboType.SelectionChangeCommitted += new System.EventHandler(this.cboType_SelectionChangeCommitted);
            this.cboType.DropDown += new System.EventHandler(this.cboType_DropDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "No. of Times:";
            // 
            // numericUpDownNumberOfTimes
            // 
            this.numericUpDownNumberOfTimes.Location = new System.Drawing.Point(360, 70);
            this.numericUpDownNumberOfTimes.Name = "numericUpDownNumberOfTimes";
            this.numericUpDownNumberOfTimes.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownNumberOfTimes.TabIndex = 11;
            this.numericUpDownNumberOfTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCurSalary
            // 
            this.lblCurSalary.AutoSize = true;
            this.lblCurSalary.Location = new System.Drawing.Point(219, 45);
            this.lblCurSalary.Name = "lblCurSalary";
            this.lblCurSalary.Size = new System.Drawing.Size(61, 13);
            this.lblCurSalary.TabIndex = 10;
            this.lblCurSalary.Text = "Cur. Salary:";
            // 
            // numericUpDownCurrentSalary
            // 
            this.numericUpDownCurrentSalary.DecimalPlaces = 2;
            this.numericUpDownCurrentSalary.Location = new System.Drawing.Point(283, 42);
            this.numericUpDownCurrentSalary.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownCurrentSalary.Name = "numericUpDownCurrentSalary";
            this.numericUpDownCurrentSalary.Size = new System.Drawing.Size(115, 20);
            this.numericUpDownCurrentSalary.TabIndex = 9;
            this.numericUpDownCurrentSalary.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(73, 91);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(347, 37);
            this.txtReason.TabIndex = 7;
            // 
            // inUseCheckBox
            // 
            this.inUseCheckBox.AutoSize = true;
            this.inUseCheckBox.Location = new System.Drawing.Point(227, 69);
            this.inUseCheckBox.Name = "inUseCheckBox";
            this.inUseCheckBox.Size = new System.Drawing.Size(56, 17);
            this.inUseCheckBox.TabIndex = 6;
            this.inUseCheckBox.Text = "Active";
            this.inUseCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Effective Date:";
            // 
            // datePickerEffectiveDate
            // 
            this.datePickerEffectiveDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerEffectiveDate.Location = new System.Drawing.Point(283, 19);
            this.datePickerEffectiveDate.Name = "datePickerEffectiveDate";
            this.datePickerEffectiveDate.ShowCheckBox = true;
            this.datePickerEffectiveDate.Size = new System.Drawing.Size(149, 20);
            this.datePickerEffectiveDate.TabIndex = 4;
            // 
            // checkBoxIncomeTax
            // 
            this.checkBoxIncomeTax.AutoSize = true;
            this.checkBoxIncomeTax.Location = new System.Drawing.Point(73, 68);
            this.checkBoxIncomeTax.Name = "checkBoxIncomeTax";
            this.checkBoxIncomeTax.Size = new System.Drawing.Size(82, 17);
            this.checkBoxIncomeTax.TabIndex = 3;
            this.checkBoxIncomeTax.Text = "Income Tax";
            this.checkBoxIncomeTax.UseVisualStyleBackColor = true;
            // 
            // checkBoxSSNIT
            // 
            this.checkBoxSSNIT.AutoSize = true;
            this.checkBoxSSNIT.Location = new System.Drawing.Point(158, 69);
            this.checkBoxSSNIT.Name = "checkBoxSSNIT";
            this.checkBoxSSNIT.Size = new System.Drawing.Size(58, 17);
            this.checkBoxSSNIT.TabIndex = 2;
            this.checkBoxSSNIT.Text = "SSNIT";
            this.checkBoxSSNIT.UseVisualStyleBackColor = true;
            // 
            // lblPrevSalary
            // 
            this.lblPrevSalary.AutoSize = true;
            this.lblPrevSalary.Location = new System.Drawing.Point(3, 45);
            this.lblPrevSalary.Name = "lblPrevSalary";
            this.lblPrevSalary.Size = new System.Drawing.Size(67, 13);
            this.lblPrevSalary.TabIndex = 1;
            this.lblPrevSalary.Text = "Prev. Salary:";
            // 
            // numericUpDownPreviousSalary
            // 
            this.numericUpDownPreviousSalary.DecimalPlaces = 2;
            this.numericUpDownPreviousSalary.Location = new System.Drawing.Point(73, 42);
            this.numericUpDownPreviousSalary.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownPreviousSalary.Name = "numericUpDownPreviousSalary";
            this.numericUpDownPreviousSalary.Size = new System.Drawing.Size(115, 20);
            this.numericUpDownPreviousSalary.TabIndex = 0;
            this.numericUpDownPreviousSalary.ThousandsSeparator = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.findbtn);
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(0, 355);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 37);
            this.panel1.TabIndex = 53;
            // 
            // findbtn
            // 
            this.findbtn.Location = new System.Drawing.Point(267, 5);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(67, 23);
            this.findbtn.TabIndex = 2;
            this.findbtn.Text = "View";
            this.findbtn.UseVisualStyleBackColor = true;
            this.findbtn.Click += new System.EventHandler(this.findbtn_Click);
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(340, 5);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(59, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(202, 5);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(59, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(137, 5);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(59, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
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
            // ArrearsNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(524, 392);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel2);
            this.Name = "ArrearsNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arrears New";
            this.Load += new System.EventHandler(this.ArrearsNew_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviousSalary)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPreView;
        private System.Windows.Forms.TextBox agetxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gendertxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label lblPrevSalary;
        private System.Windows.Forms.NumericUpDown numericUpDownPreviousSalary;
        private System.Windows.Forms.CheckBox checkBoxIncomeTax;
        private System.Windows.Forms.CheckBox checkBoxSSNIT;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker datePickerEffectiveDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.CheckBox inUseCheckBox;
        private System.Windows.Forms.Button findbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfTimes;
        private System.Windows.Forms.Label lblCurSalary;
        private System.Windows.Forms.NumericUpDown numericUpDownCurrentSalary;
    }
}