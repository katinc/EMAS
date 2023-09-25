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
            this.cboIST = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTrainingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridIST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridOrganisers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCertificateAwarded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridVenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCostFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccomodationFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTransportationFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSponsor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLocationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // cboIST
            // 
            this.cboIST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIST.FormattingEnabled = true;
            this.cboIST.Location = new System.Drawing.Point(267, 15);
            this.cboIST.Name = "cboIST";
            this.cboIST.Size = new System.Drawing.Size(150, 21);
            this.cboIST.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "IST:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboCourse);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.staffIDtxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nametxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboTrainingType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboIST);
            this.groupBox1.Location = new System.Drawing.Point(2, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 99);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterior";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(420, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Course:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(422, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Venue:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(267, 69);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(150, 20);
            this.dateTimePicker2.TabIndex = 38;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(75, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(143, 20);
            this.dateTimePicker1.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(221, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "DateTo:";
            // 
            // cboCourse
            // 
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(466, 14);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(151, 21);
            this.cboCourse.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "DateFrom:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(466, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 33;
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.Location = new System.Drawing.Point(267, 42);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(149, 20);
            this.staffIDtxt.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Staff ID:";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(75, 42);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(143, 20);
            this.nametxt.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Name:";
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
            this.gridIST,
            this.gridStartDate,
            this.gridEndDate,
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
            this.grid.Size = new System.Drawing.Size(617, 241);
            this.grid.TabIndex = 6;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
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
            this.btnClose.Location = new System.Drawing.Point(506, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(409, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Cancel";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
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
            // 
            // gridIST
            // 
            this.gridIST.HeaderText = "IST";
            this.gridIST.Name = "gridIST";
            this.gridIST.Visible = false;
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
            // gridOrganisers
            // 
            this.gridOrganisers.HeaderText = "Organisers";
            this.gridOrganisers.Name = "gridOrganisers";
            // 
            // gridCertificateAwarded
            // 
            this.gridCertificateAwarded.HeaderText = "Certificate Awarded";
            this.gridCertificateAwarded.Name = "gridCertificateAwarded";
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
            // 
            // gridAccomodationFee
            // 
            this.gridAccomodationFee.HeaderText = "Accomodation Fee";
            this.gridAccomodationFee.Name = "gridAccomodationFee";
            // 
            // gridTransportationFee
            // 
            this.gridTransportationFee.HeaderText = "Transportation Fee";
            this.gridTransportationFee.Name = "gridTransportationFee";
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
            // TrainingViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 438);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
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
        private System.Windows.Forms.ComboBox cboIST;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTrainingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIST;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridOrganisers;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCertificateAwarded;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridVenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCostFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccomodationFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTransportationFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSponsor;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLocationType;
    }
}