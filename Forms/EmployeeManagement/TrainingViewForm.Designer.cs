namespace eMAS.Forms.EmployeeManagement
{
    partial class TrainingViewForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTrainingType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtVenue = new System.Windows.Forms.TextBox();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTrainingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridOrganisers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCertificateAwarded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridVenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCostFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccomodationFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTransportationFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSponsor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLocationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 29);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "View Training Program";
            // 
            // cboTrainingType
            // 
            this.cboTrainingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainingType.FormattingEnabled = true;
            this.cboTrainingType.Location = new System.Drawing.Point(75, 16);
            this.cboTrainingType.Name = "cboTrainingType";
            this.cboTrainingType.Size = new System.Drawing.Size(143, 21);
            this.cboTrainingType.TabIndex = 1;
            this.cboTrainingType.DropDown += new System.EventHandler(this.cboTrainingType_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Training Type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateStartDate);
            this.groupBox1.Controls.Add(this.dateEndDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtVenue);
            this.groupBox1.Controls.Add(this.staffIDtxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboTrainingType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 99);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterior";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Venue:";
            // 
            // dateStartDate
            // 
            this.dateStartDate.Checked = false;
            this.dateStartDate.CustomFormat = "MM/dd/yyyy";
            this.dateStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartDate.Location = new System.Drawing.Point(75, 69);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.ShowCheckBox = true;
            this.dateStartDate.Size = new System.Drawing.Size(143, 20);
            this.dateStartDate.TabIndex = 70;
            this.dateStartDate.Value = new System.DateTime(2019, 1, 15, 0, 0, 0, 0);
            this.dateStartDate.CloseUp += new System.EventHandler(this.attedanceDate_CloseUp);
            this.dateStartDate.ValueChanged += new System.EventHandler(this.attedanceDate_ValueChanged);
            // 
            // dateEndDate
            // 
            this.dateEndDate.Checked = false;
            this.dateEndDate.CustomFormat = "MM/dd/yyyy";
            this.dateEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndDate.Location = new System.Drawing.Point(284, 43);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.ShowCheckBox = true;
            this.dateEndDate.Size = new System.Drawing.Size(151, 20);
            this.dateEndDate.TabIndex = 70;
            this.dateEndDate.Value = new System.DateTime(2019, 1, 15, 0, 0, 0, 0);
            this.dateEndDate.CloseUp += new System.EventHandler(this.attedanceDate_CloseUp);
            this.dateEndDate.ValueChanged += new System.EventHandler(this.attedanceDate_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "End Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Start Date";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(462, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 47);
            this.btnSearch.TabIndex = 51;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtVenue
            // 
            this.txtVenue.Location = new System.Drawing.Point(284, 17);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.Size = new System.Drawing.Size(151, 20);
            this.txtVenue.TabIndex = 33;
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(75, 43);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(143, 20);
            this.staffIDtxt.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Staff ID:";
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridStaffID,
            this.gridStaffName,
            this.gridTrainingType,
            this.gridCourse,
            this.gridStartDate,
            this.gridEndDate,
            this.gridHours,
            this.gridDuration,
            this.gridOrganisers,
            this.gridCertificateAwarded,
            this.gridVenue,
            this.gridTotalCost,
            this.gridCostFee,
            this.gridAccomodationFee,
            this.gridTransportationFee,
            this.gridSponsor,
            this.gridLocationType});
            this.grid.Location = new System.Drawing.Point(1, 19);
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(617, 241);
            this.grid.TabIndex = 6;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick_1);
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.Visible = false;
            // 
            // gridStaffID
            // 
            this.gridStaffID.HeaderText = "StaffID";
            this.gridStaffID.Name = "gridStaffID";
            // 
            // gridStaffName
            // 
            this.gridStaffName.HeaderText = "StaffName";
            this.gridStaffName.Name = "gridStaffName";
            this.gridStaffName.Width = 200;
            // 
            // gridTrainingType
            // 
            this.gridTrainingType.HeaderText = "Training Type";
            this.gridTrainingType.Name = "gridTrainingType";
            // 
            // gridCourse
            // 
            this.gridCourse.HeaderText = "Course";
            this.gridCourse.Name = "gridCourse";
            this.gridCourse.Visible = false;
            // 
            // gridStartDate
            // 
            this.gridStartDate.HeaderText = "StartDate";
            this.gridStartDate.Name = "gridStartDate";
            // 
            // gridEndDate
            // 
            this.gridEndDate.HeaderText = "End Date";
            this.gridEndDate.Name = "gridEndDate";
            // 
            // gridHours
            // 
            this.gridHours.HeaderText = "Hours";
            this.gridHours.Name = "gridHours";
            // 
            // gridDuration
            // 
            this.gridDuration.HeaderText = "Duration(Days)";
            this.gridDuration.Name = "gridDuration";
            // 
            // gridOrganisers
            // 
            this.gridOrganisers.HeaderText = "Organisers";
            this.gridOrganisers.Name = "gridOrganisers";
            // 
            // gridCertificateAwarded
            // 
            this.gridCertificateAwarded.HeaderText = "Certificate Awarded";
            this.gridCertificateAwarded.Name = "gridCertificateAwarded";
            this.gridCertificateAwarded.Visible = false;
            // 
            // gridVenue
            // 
            this.gridVenue.HeaderText = "Venue";
            this.gridVenue.Name = "gridVenue";
            // 
            // gridTotalCost
            // 
            this.gridTotalCost.HeaderText = "Total Cost";
            this.gridTotalCost.Name = "gridTotalCost";
            // 
            // gridCostFee
            // 
            this.gridCostFee.HeaderText = "Cost Fee";
            this.gridCostFee.Name = "gridCostFee";
            this.gridCostFee.Visible = false;
            // 
            // gridAccomodationFee
            // 
            this.gridAccomodationFee.HeaderText = "Accomodation Fee";
            this.gridAccomodationFee.Name = "gridAccomodationFee";
            this.gridAccomodationFee.Visible = false;
            // 
            // gridTransportationFee
            // 
            this.gridTransportationFee.HeaderText = "Transportation Fee";
            this.gridTransportationFee.Name = "gridTransportationFee";
            this.gridTransportationFee.Visible = false;
            // 
            // gridSponsor
            // 
            this.gridSponsor.HeaderText = "Sponsor";
            this.gridSponsor.Name = "gridSponsor";
            // 
            // gridLocationType
            // 
            this.gridLocationType.HeaderText = "Location Type";
            this.gridLocationType.Name = "gridLocationType";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.Location = new System.Drawing.Point(3, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 266);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Result";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnRemove);
            this.panel3.Location = new System.Drawing.Point(3, 410);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(624, 28);
            this.panel3.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(543, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(462, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "StaffID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "StaffName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Training Type";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Course";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "IST";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "StartDate";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "End Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Organisers";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Certificate Awarded";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Venue";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Total Cost";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Cost Fee";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Accomodation Fee";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Transportation Fee";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Sponsor";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Location Type";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Location Type";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // TrainingViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 438);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "TrainingViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Of Staff Training";
            this.Load += new System.EventHandler(this.TrainingViewForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTrainingType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVenue;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIST;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.DateTimePicker dateStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTrainingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridOrganisers;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCertificateAwarded;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridVenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCostFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccomodationFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTransportationFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSponsor;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLocationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
    }
}