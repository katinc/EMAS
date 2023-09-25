namespace eMAS.Forms.SystemSetup
{
    partial class AnnualLeaveEntitlementForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.checkIncludeHolidays = new System.Windows.Forms.CheckBox();
            this.checkIncludeWeekends = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.gradecategoriesListBox = new System.Windows.Forms.CheckedListBox();
            this.numericPromotionYears = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericID = new System.Windows.Forms.NumericUpDown();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericNumberofDays = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCategoryOfPost = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCategoryOfPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGradeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridNumberOfDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPromotionYears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridIncludeHolidays = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridIncludeWeekends = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPromotionYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberofDays)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(815, 29);
            this.panel2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(6, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Category Entitlement Form";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBoxSearch.Controls.Add(this.cmbStatus);
            this.groupBoxSearch.Controls.Add(this.checkIncludeHolidays);
            this.groupBoxSearch.Controls.Add(this.checkIncludeWeekends);
            this.groupBoxSearch.Controls.Add(this.groupBox2);
            this.groupBoxSearch.Controls.Add(this.numericPromotionYears);
            this.groupBoxSearch.Controls.Add(this.label7);
            this.groupBoxSearch.Controls.Add(this.label6);
            this.groupBoxSearch.Controls.Add(this.numericID);
            this.groupBoxSearch.Controls.Add(this.checkBoxActive);
            this.groupBoxSearch.Controls.Add(this.label5);
            this.groupBoxSearch.Controls.Add(this.numericNumberofDays);
            this.groupBoxSearch.Controls.Add(this.btnAdd);
            this.groupBoxSearch.Controls.Add(this.label4);
            this.groupBoxSearch.Controls.Add(this.label2);
            this.groupBoxSearch.Controls.Add(this.txtCategoryOfPost);
            this.groupBoxSearch.Location = new System.Drawing.Point(0, 29);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(815, 228);
            this.groupBoxSearch.TabIndex = 5;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Filters";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Senior Staff",
            "Middle Staff",
            "Junior Staff"});
            this.cmbStatus.Location = new System.Drawing.Point(105, 61);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 22;
            // 
            // checkIncludeHolidays
            // 
            this.checkIncludeHolidays.AutoSize = true;
            this.checkIncludeHolidays.Location = new System.Drawing.Point(106, 132);
            this.checkIncludeHolidays.Name = "checkIncludeHolidays";
            this.checkIncludeHolidays.Size = new System.Drawing.Size(104, 17);
            this.checkIncludeHolidays.TabIndex = 21;
            this.checkIncludeHolidays.Text = "Include Holidays";
            this.checkIncludeHolidays.UseVisualStyleBackColor = true;
            // 
            // checkIncludeWeekends
            // 
            this.checkIncludeWeekends.AutoSize = true;
            this.checkIncludeWeekends.Location = new System.Drawing.Point(106, 112);
            this.checkIncludeWeekends.Name = "checkIncludeWeekends";
            this.checkIncludeWeekends.Size = new System.Drawing.Size(116, 17);
            this.checkIncludeWeekends.TabIndex = 20;
            this.checkIncludeWeekends.Text = "Include Weekends";
            this.checkIncludeWeekends.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSelectAll);
            this.groupBox2.Controls.Add(this.gradecategoriesListBox);
            this.groupBox2.Location = new System.Drawing.Point(348, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 203);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Applicable Grade Categories";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(16, 180);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(71, 17);
            this.chkSelectAll.TabIndex = 23;
            this.chkSelectAll.Text = "Check All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // gradecategoriesListBox
            // 
            this.gradecategoriesListBox.FormattingEnabled = true;
            this.gradecategoriesListBox.Location = new System.Drawing.Point(16, 21);
            this.gradecategoriesListBox.Name = "gradecategoriesListBox";
            this.gradecategoriesListBox.ScrollAlwaysVisible = true;
            this.gradecategoriesListBox.Size = new System.Drawing.Size(412, 139);
            this.gradecategoriesListBox.TabIndex = 0;
            this.gradecategoriesListBox.SelectedIndexChanged += new System.EventHandler(this.gradecategoriesListBox_SelectedIndexChanged);
            // 
            // numericPromotionYears
            // 
            this.numericPromotionYears.Location = new System.Drawing.Point(105, 151);
            this.numericPromotionYears.Name = "numericPromotionYears";
            this.numericPromotionYears.Size = new System.Drawing.Size(115, 20);
            this.numericPromotionYears.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Promotion Years:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "ID:";
            // 
            // numericID
            // 
            this.numericID.Enabled = false;
            this.numericID.Location = new System.Drawing.Point(106, 16);
            this.numericID.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericID.Name = "numericID";
            this.numericID.Size = new System.Drawing.Size(120, 20);
            this.numericID.TabIndex = 12;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(106, 177);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActive.TabIndex = 11;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Number of  Days:";
            // 
            // numericNumberofDays
            // 
            this.numericNumberofDays.Location = new System.Drawing.Point(106, 86);
            this.numericNumberofDays.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numericNumberofDays.Name = "numericNumberofDays";
            this.numericNumberofDays.Size = new System.Drawing.Size(120, 20);
            this.numericNumberofDays.TabIndex = 9;
            this.numericNumberofDays.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(106, 200);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(186, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Category of Post: ";
            // 
            // txtCategoryOfPost
            // 
            this.txtCategoryOfPost.Location = new System.Drawing.Point(106, 38);
            this.txtCategoryOfPost.Name = "txtCategoryOfPost";
            this.txtCategoryOfPost.Size = new System.Drawing.Size(120, 20);
            this.txtCategoryOfPost.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Location = new System.Drawing.Point(6, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 299);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // grid
            // 
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridStatus,
            this.gridCategoryOfPost,
            this.gridGradeType,
            this.gridNumberOfDays,
            this.gridPromotionYears,
            this.gridActive,
            this.gridIncludeHolidays,
            this.gridIncludeWeekends,
            this.gridUserID});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 16);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 21;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(782, 280);
            this.grid.TabIndex = 0;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            // 
            // gridStatus
            // 
            this.gridStatus.FillWeight = 105.9648F;
            this.gridStatus.HeaderText = "Status";
            this.gridStatus.Name = "gridStatus";
            // 
            // gridCategoryOfPost
            // 
            this.gridCategoryOfPost.FillWeight = 48.95336F;
            this.gridCategoryOfPost.HeaderText = "Cat. Post";
            this.gridCategoryOfPost.Name = "gridCategoryOfPost";
            // 
            // gridGradeType
            // 
            this.gridGradeType.FillWeight = 109.8484F;
            this.gridGradeType.HeaderText = "Type of Grade";
            this.gridGradeType.Name = "gridGradeType";
            this.gridGradeType.ReadOnly = true;
            // 
            // gridNumberOfDays
            // 
            this.gridNumberOfDays.FillWeight = 50F;
            this.gridNumberOfDays.HeaderText = "No. Of Days";
            this.gridNumberOfDays.Name = "gridNumberOfDays";
            // 
            // gridPromotionYears
            // 
            this.gridPromotionYears.HeaderText = "Promo. Yrs";
            this.gridPromotionYears.Name = "gridPromotionYears";
            // 
            // gridActive
            // 
            this.gridActive.FillWeight = 48.95336F;
            this.gridActive.HeaderText = "Active";
            this.gridActive.Name = "gridActive";
            this.gridActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridIncludeHolidays
            // 
            this.gridIncludeHolidays.HeaderText = "Include Holidays";
            this.gridIncludeHolidays.Name = "gridIncludeHolidays";
            this.gridIncludeHolidays.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridIncludeHolidays.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridIncludeWeekends
            // 
            this.gridIncludeWeekends.HeaderText = "Include Weekends";
            this.gridIncludeWeekends.Name = "gridIncludeWeekends";
            this.gridIncludeWeekends.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridIncludeWeekends.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridUserID
            // 
            this.gridUserID.HeaderText = "UserID";
            this.gridUserID.Name = "gridUserID";
            this.gridUserID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 564);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 42);
            this.panel1.TabIndex = 27;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(494, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(575, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(647, 9);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(66, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(719, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 108.2304F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Status";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 156;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 50F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Cat. Post";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 72;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 112.197F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Type of Grade";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 162;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 50F;
            this.dataGridViewTextBoxColumn5.HeaderText = "No. Of Days";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 69;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Promo. Yrs";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 108;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "UserID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // AnnualLeaveEntitlementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 605);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "AnnualLeaveEntitlementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category Entitlement Form";
            this.Load += new System.EventHandler(this.AnnualLeaveEntitlementForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPromotionYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberofDays)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCategoryOfPost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericNumberofDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.NumericUpDown numericID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericPromotionYears;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox gradecategoriesListBox;
        private System.Windows.Forms.CheckBox checkIncludeHolidays;
        private System.Windows.Forms.CheckBox checkIncludeWeekends;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCategoryOfPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGradeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNumberOfDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridPromotionYears;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridActive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridIncludeHolidays;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridIncludeWeekends;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
        private System.Windows.Forms.CheckBox chkSelectAll;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button deleteButton;
    }
}