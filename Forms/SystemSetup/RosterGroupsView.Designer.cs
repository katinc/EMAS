namespace eMAS.Forms.SystemSetup
{
    partial class RosterGroupsView
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
            dal.CloseConnection();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRoasterGroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMonday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridTuesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridWednesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridThursday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridFriday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridSaturday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridSunday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.viewButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(-17, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 34);
            this.panel1.TabIndex = 39;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(777, 3);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(60, 23);
            this.viewButton.TabIndex = 5;
            this.viewButton.Text = "Remove";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(843, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 33);
            this.panel2.TabIndex = 38;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Roster Groups";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridShiftID,
            this.gridRoasterGroupID,
            this.gridName,
            this.gridShift,
            this.gridMonday,
            this.gridTuesday,
            this.gridWednesday,
            this.gridThursday,
            this.gridFriday,
            this.gridSaturday,
            this.gridSunday,
            this.gridUserID});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 16);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(869, 414);
            this.grid.TabIndex = 40;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            // 
            // gridShiftID
            // 
            this.gridShiftID.HeaderText = "ShiftID";
            this.gridShiftID.Name = "gridShiftID";
            this.gridShiftID.ReadOnly = true;
            this.gridShiftID.Visible = false;
            this.gridShiftID.Width = 92;
            // 
            // gridRoasterGroupID
            // 
            this.gridRoasterGroupID.HeaderText = "RoasterGroupID";
            this.gridRoasterGroupID.Name = "gridRoasterGroupID";
            this.gridRoasterGroupID.ReadOnly = true;
            this.gridRoasterGroupID.Visible = false;
            // 
            // gridName
            // 
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 252;
            // 
            // gridShift
            // 
            this.gridShift.HeaderText = "Shift";
            this.gridShift.Name = "gridShift";
            this.gridShift.ReadOnly = true;
            // 
            // gridMonday
            // 
            this.gridMonday.HeaderText = "Monday";
            this.gridMonday.Name = "gridMonday";
            this.gridMonday.ReadOnly = true;
            this.gridMonday.Width = 80;
            // 
            // gridTuesday
            // 
            this.gridTuesday.HeaderText = "Tuesday";
            this.gridTuesday.Name = "gridTuesday";
            this.gridTuesday.ReadOnly = true;
            this.gridTuesday.Width = 80;
            // 
            // gridWednesday
            // 
            this.gridWednesday.HeaderText = "Wednesday";
            this.gridWednesday.Name = "gridWednesday";
            this.gridWednesday.ReadOnly = true;
            this.gridWednesday.Width = 90;
            // 
            // gridThursday
            // 
            this.gridThursday.HeaderText = "Thursday";
            this.gridThursday.Name = "gridThursday";
            this.gridThursday.ReadOnly = true;
            this.gridThursday.Width = 80;
            // 
            // gridFriday
            // 
            this.gridFriday.HeaderText = "Friday";
            this.gridFriday.Name = "gridFriday";
            this.gridFriday.ReadOnly = true;
            this.gridFriday.Width = 80;
            // 
            // gridSaturday
            // 
            this.gridSaturday.HeaderText = "Saturday";
            this.gridSaturday.Name = "gridSaturday";
            this.gridSaturday.ReadOnly = true;
            this.gridSaturday.Width = 80;
            // 
            // gridSunday
            // 
            this.gridSunday.HeaderText = "Sunday";
            this.gridSunday.Name = "gridSunday";
            this.gridSunday.ReadOnly = true;
            this.gridSunday.Width = 80;
            // 
            // gridUserID
            // 
            this.gridUserID.HeaderText = "UserID";
            this.gridUserID.Name = "gridUserID";
            this.gridUserID.ReadOnly = true;
            this.gridUserID.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 433);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
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
            this.dataGridViewTextBoxColumn2.HeaderText = "Shift";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ShiftID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 92;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "RoasterGroupID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 252;
            // 
            // RosterGroupsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(899, 528);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "RosterGroupsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RosterGroupsView";
            this.Load += new System.EventHandler(this.RosterGroupsView_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRoasterGroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridShift;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridMonday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridTuesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridWednesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridThursday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridFriday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridSaturday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridSunday;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
    }
}