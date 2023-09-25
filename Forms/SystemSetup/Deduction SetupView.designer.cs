namespace eMAS.All_UIs.System_SetupFORMS
{
    partial class DeductionSetupView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDeductionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDeductionTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDeductionCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDeductionCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSalaryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRateBased = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridSalaryTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridInActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Location = new System.Drawing.Point(3, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 366);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.Color.DarkGray;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridDeductionType,
            this.gridDeductionTypeID,
            this.gridCode,
            this.gridDescription,
            this.gridDeductionCategory,
            this.gridDeductionCategoryID,
            this.gridRate,
            this.gridSalaryType,
            this.gridAmount,
            this.gridRateBased,
            this.gridSalaryTypeID,
            this.gridInActive,
            this.gridUserID});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.GridColor = System.Drawing.Color.LightGray;
            this.grid.Location = new System.Drawing.Point(3, 16);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 21;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(723, 347);
            this.grid.TabIndex = 0;
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            // 
            // gridDeductionType
            // 
            this.gridDeductionType.HeaderText = "Deduction Type";
            this.gridDeductionType.Name = "gridDeductionType";
            this.gridDeductionType.ReadOnly = true;
            this.gridDeductionType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDeductionType.Width = 120;
            // 
            // gridDeductionTypeID
            // 
            this.gridDeductionTypeID.HeaderText = "Deduction Type ID";
            this.gridDeductionTypeID.Name = "gridDeductionTypeID";
            this.gridDeductionTypeID.ReadOnly = true;
            this.gridDeductionTypeID.Visible = false;
            // 
            // gridCode
            // 
            this.gridCode.HeaderText = "Code";
            this.gridCode.Name = "gridCode";
            this.gridCode.ReadOnly = true;
            // 
            // gridDescription
            // 
            this.gridDescription.HeaderText = "Description";
            this.gridDescription.Name = "gridDescription";
            this.gridDescription.ReadOnly = true;
            this.gridDescription.Width = 200;
            // 
            // gridDeductionCategory
            // 
            this.gridDeductionCategory.HeaderText = "Deduction Category";
            this.gridDeductionCategory.Name = "gridDeductionCategory";
            this.gridDeductionCategory.ReadOnly = true;
            this.gridDeductionCategory.Width = 150;
            // 
            // gridDeductionCategoryID
            // 
            this.gridDeductionCategoryID.HeaderText = "Deduction Category ID";
            this.gridDeductionCategoryID.Name = "gridDeductionCategoryID";
            this.gridDeductionCategoryID.ReadOnly = true;
            this.gridDeductionCategoryID.Visible = false;
            // 
            // gridRate
            // 
            this.gridRate.HeaderText = "Rate";
            this.gridRate.Name = "gridRate";
            this.gridRate.ReadOnly = true;
            this.gridRate.Width = 50;
            // 
            // gridSalaryType
            // 
            this.gridSalaryType.HeaderText = "CalculatedOn";
            this.gridSalaryType.Name = "gridSalaryType";
            this.gridSalaryType.ReadOnly = true;
            this.gridSalaryType.Width = 120;
            // 
            // gridAmount
            // 
            this.gridAmount.HeaderText = "Fixed Amount";
            this.gridAmount.Name = "gridAmount";
            this.gridAmount.ReadOnly = true;
            // 
            // gridRateBased
            // 
            this.gridRateBased.HeaderText = "Rate Based";
            this.gridRateBased.Name = "gridRateBased";
            this.gridRateBased.ReadOnly = true;
            // 
            // gridSalaryTypeID
            // 
            this.gridSalaryTypeID.HeaderText = "Salary Type ID";
            this.gridSalaryTypeID.Name = "gridSalaryTypeID";
            this.gridSalaryTypeID.ReadOnly = true;
            this.gridSalaryTypeID.Visible = false;
            // 
            // gridInActive
            // 
            this.gridInActive.HeaderText = "Active";
            this.gridInActive.Name = "gridInActive";
            this.gridInActive.ReadOnly = true;
            this.gridInActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridInActive.Width = 60;
            // 
            // gridUserID
            // 
            this.gridUserID.HeaderText = "UserID";
            this.gridUserID.Name = "gridUserID";
            this.gridUserID.ReadOnly = true;
            this.gridUserID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Location = new System.Drawing.Point(0, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 37);
            this.panel1.TabIndex = 22;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(664, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(594, 6);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(64, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 28);
            this.panel2.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deductions";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Deduction Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Deduction Type ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Description";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Deduction Category";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Deduction Category ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Rate";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "CalculatedOn";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Salary Type ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // DeductionSetupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(737, 454);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "DeductionSetupView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeductionSetupView";
            this.Load += new System.EventHandler(this.DeductionSetupView_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDeductionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDeductionTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDeductionCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDeductionCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSalaryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridRateBased;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSalaryTypeID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridInActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
        public System.Windows.Forms.Button btnDelete;
    }
}