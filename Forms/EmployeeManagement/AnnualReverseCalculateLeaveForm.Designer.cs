namespace eMAS.Forms.EmployeeManagement
{
    partial class AnnualReverseCalculateLeaveForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonBy = new System.Windows.Forms.RadioButton();
            this.cboLeaveEntitlement = new System.Windows.Forms.ComboBox();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonIndividual = new System.Windows.Forms.RadioButton();
            this.yearLabel = new System.Windows.Forms.Label();
            this.periodGroupBox = new System.Windows.Forms.GroupBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfDays = new System.Windows.Forms.NumericUpDown();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.groupBoxStaff = new System.Windows.Forms.GroupBox();
            this.txtLeaveEntitlement = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gendertxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.periodGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfDays)).BeginInit();
            this.groupBoxStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 30);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reverse Calculation Of Annual Leave";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonBy);
            this.groupBox1.Controls.Add(this.cboLeaveEntitlement);
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Controls.Add(this.radioButtonIndividual);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 69);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criteria";
            // 
            // radioButtonBy
            // 
            this.radioButtonBy.AutoSize = true;
            this.radioButtonBy.Location = new System.Drawing.Point(81, 16);
            this.radioButtonBy.Name = "radioButtonBy";
            this.radioButtonBy.Size = new System.Drawing.Size(37, 17);
            this.radioButtonBy.TabIndex = 7;
            this.radioButtonBy.TabStop = true;
            this.radioButtonBy.Text = "By";
            this.radioButtonBy.UseVisualStyleBackColor = true;
            this.radioButtonBy.CheckedChanged += new System.EventHandler(this.radioButtonBy_CheckedChanged);
            // 
            // cboLeaveEntitlement
            // 
            this.cboLeaveEntitlement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaveEntitlement.FormattingEnabled = true;
            this.cboLeaveEntitlement.Location = new System.Drawing.Point(81, 39);
            this.cboLeaveEntitlement.Name = "cboLeaveEntitlement";
            this.cboLeaveEntitlement.Size = new System.Drawing.Size(175, 21);
            this.cboLeaveEntitlement.TabIndex = 6;
            this.cboLeaveEntitlement.Visible = false;
            this.cboLeaveEntitlement.DropDown += new System.EventHandler(this.cboLeaveEntitlement_DropDown);
            this.cboLeaveEntitlement.SelectionChangeCommitted += new System.EventHandler(this.cboLeaveEntitlement_SelectionChangeCommitted);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(7, 16);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(36, 17);
            this.radioButtonAll.TabIndex = 3;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // radioButtonIndividual
            // 
            this.radioButtonIndividual.AutoSize = true;
            this.radioButtonIndividual.Location = new System.Drawing.Point(7, 43);
            this.radioButtonIndividual.Name = "radioButtonIndividual";
            this.radioButtonIndividual.Size = new System.Drawing.Size(70, 17);
            this.radioButtonIndividual.TabIndex = 2;
            this.radioButtonIndividual.TabStop = true;
            this.radioButtonIndividual.Text = "Individual";
            this.radioButtonIndividual.UseVisualStyleBackColor = true;
            this.radioButtonIndividual.CheckedChanged += new System.EventHandler(this.radioButtonIndividual_CheckedChanged);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.BackColor = System.Drawing.Color.Transparent;
            this.yearLabel.Location = new System.Drawing.Point(8, 22);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(32, 13);
            this.yearLabel.TabIndex = 0;
            this.yearLabel.Text = "Year:";
            // 
            // periodGroupBox
            // 
            this.periodGroupBox.Controls.Add(this.lblDays);
            this.periodGroupBox.Controls.Add(this.numericUpDownNumberOfDays);
            this.periodGroupBox.Controls.Add(this.yearComboBox);
            this.periodGroupBox.Controls.Add(this.yearLabel);
            this.periodGroupBox.Location = new System.Drawing.Point(274, 37);
            this.periodGroupBox.Name = "periodGroupBox";
            this.periodGroupBox.Size = new System.Drawing.Size(158, 69);
            this.periodGroupBox.TabIndex = 16;
            this.periodGroupBox.TabStop = false;
            this.periodGroupBox.Text = "Period";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(6, 46);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(34, 13);
            this.lblDays.TabIndex = 33;
            this.lblDays.Text = "Days:";
            this.lblDays.Visible = false;
            // 
            // numericUpDownNumberOfDays
            // 
            this.numericUpDownNumberOfDays.Location = new System.Drawing.Point(43, 42);
            this.numericUpDownNumberOfDays.Name = "numericUpDownNumberOfDays";
            this.numericUpDownNumberOfDays.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownNumberOfDays.TabIndex = 32;
            this.numericUpDownNumberOfDays.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownNumberOfDays.Visible = false;
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(43, 18);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(106, 21);
            this.yearComboBox.TabIndex = 1;
            this.yearComboBox.DropDown += new System.EventHandler(this.yearComboBox_DropDown);
            // 
            // groupBoxStaff
            // 
            this.groupBoxStaff.Controls.Add(this.txtLeaveEntitlement);
            this.groupBoxStaff.Controls.Add(this.label12);
            this.groupBoxStaff.Controls.Add(this.gendertxt);
            this.groupBoxStaff.Controls.Add(this.label11);
            this.groupBoxStaff.Controls.Add(this.staffIDtxt);
            this.groupBoxStaff.Controls.Add(this.label2);
            this.groupBoxStaff.Controls.Add(this.nametxt);
            this.groupBoxStaff.Controls.Add(this.label3);
            this.groupBoxStaff.Controls.Add(this.searchGrid);
            this.groupBoxStaff.Location = new System.Drawing.Point(11, 112);
            this.groupBoxStaff.Name = "groupBoxStaff";
            this.groupBoxStaff.Size = new System.Drawing.Size(420, 140);
            this.groupBoxStaff.TabIndex = 18;
            this.groupBoxStaff.TabStop = false;
            this.groupBoxStaff.Text = "Staff";
            // 
            // txtLeaveEntitlement
            // 
            this.txtLeaveEntitlement.BackColor = System.Drawing.Color.White;
            this.txtLeaveEntitlement.Location = new System.Drawing.Point(98, 79);
            this.txtLeaveEntitlement.Name = "txtLeaveEntitlement";
            this.txtLeaveEntitlement.ReadOnly = true;
            this.txtLeaveEntitlement.Size = new System.Drawing.Size(194, 20);
            this.txtLeaveEntitlement.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Leave Entitlemnt.:";
            // 
            // gendertxt
            // 
            this.gendertxt.BackColor = System.Drawing.Color.White;
            this.gendertxt.Location = new System.Drawing.Point(98, 57);
            this.gendertxt.Name = "gendertxt";
            this.gendertxt.ReadOnly = true;
            this.gendertxt.Size = new System.Drawing.Size(143, 20);
            this.gendertxt.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Gender:";
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(98, 13);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(143, 20);
            this.staffIDtxt.TabIndex = 23;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Staff ID:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(98, 35);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(194, 20);
            this.nametxt.TabIndex = 22;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 20;
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
            this.gridStaffCode,
            this.gridStaffNo});
            this.searchGrid.Location = new System.Drawing.Point(98, 29);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersVisible = false;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(258, 101);
            this.searchGrid.TabIndex = 28;
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
            // gridStaffCode
            // 
            this.gridStaffCode.HeaderText = "StaffCode";
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.ReadOnly = true;
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffsID";
            this.gridStaffNo.HeaderText = "Staff No";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnCalculate);
            this.panel2.Location = new System.Drawing.Point(2, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 27);
            this.panel2.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(260, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(171, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(82, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
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
            this.dataGridViewTextBoxColumn2.HeaderText = "StaffCode";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StaffsID";
            this.dataGridViewTextBoxColumn3.HeaderText = "Staff No";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // AnnualReverseCalculateLeaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 286);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBoxStaff);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.periodGroupBox);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "AnnualReverseCalculateLeaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reverse Calculation Of Annual Leave";
            this.Load += new System.EventHandler(this.AnnualReverseCalculateLeaveForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.periodGroupBox.ResumeLayout(false);
            this.periodGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfDays)).EndInit();
            this.groupBoxStaff.ResumeLayout(false);
            this.groupBoxStaff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonIndividual;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.GroupBox periodGroupBox;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.GroupBox groupBoxStaff;
        private System.Windows.Forms.TextBox gendertxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfDays;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ComboBox cboLeaveEntitlement;
        private System.Windows.Forms.RadioButton radioButtonBy;
        private System.Windows.Forms.TextBox txtLeaveEntitlement;
        private System.Windows.Forms.Label label12;
    }
}