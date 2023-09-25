namespace eMAS.Forms.SystemSetup
{
    partial class SanctionTypeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.checkBoxReinstatement = new System.Windows.Forms.CheckBox();
            this.checkBoxSeparation = new System.Windows.Forms.CheckBox();
            this.checkBoxPayment = new System.Windows.Forms.CheckBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPayment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridSeparation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridReinstatement = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 34);
            this.panel1.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sanction Types";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBoxSearch.Controls.Add(this.checkBoxReinstatement);
            this.groupBoxSearch.Controls.Add(this.checkBoxSeparation);
            this.groupBoxSearch.Controls.Add(this.checkBoxPayment);
            this.groupBoxSearch.Controls.Add(this.checkBoxActive);
            this.groupBoxSearch.Controls.Add(this.label1);
            this.groupBoxSearch.Controls.Add(this.txtDescription);
            this.groupBoxSearch.Location = new System.Drawing.Point(1, 38);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(547, 66);
            this.groupBoxSearch.TabIndex = 19;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Filters";
            // 
            // checkBoxReinstatement
            // 
            this.checkBoxReinstatement.AutoSize = true;
            this.checkBoxReinstatement.Location = new System.Drawing.Point(274, 43);
            this.checkBoxReinstatement.Name = "checkBoxReinstatement";
            this.checkBoxReinstatement.Size = new System.Drawing.Size(121, 17);
            this.checkBoxReinstatement.TabIndex = 6;
            this.checkBoxReinstatement.Text = "For Reinstatement ?";
            this.checkBoxReinstatement.UseVisualStyleBackColor = true;
            this.checkBoxReinstatement.CheckedChanged += new System.EventHandler(this.checkBoxReinstatement_CheckedChanged);
            // 
            // checkBoxSeparation
            // 
            this.checkBoxSeparation.AutoSize = true;
            this.checkBoxSeparation.Location = new System.Drawing.Point(133, 42);
            this.checkBoxSeparation.Name = "checkBoxSeparation";
            this.checkBoxSeparation.Size = new System.Drawing.Size(119, 17);
            this.checkBoxSeparation.TabIndex = 5;
            this.checkBoxSeparation.Text = "Cause Separation ?";
            this.checkBoxSeparation.UseVisualStyleBackColor = true;
            this.checkBoxSeparation.CheckedChanged += new System.EventHandler(this.checkBoxSeparation_CheckedChanged);
            // 
            // checkBoxPayment
            // 
            this.checkBoxPayment.AutoSize = true;
            this.checkBoxPayment.Location = new System.Drawing.Point(9, 43);
            this.checkBoxPayment.Name = "checkBoxPayment";
            this.checkBoxPayment.Size = new System.Drawing.Size(107, 17);
            this.checkBoxPayment.TabIndex = 4;
            this.checkBoxPayment.Text = "Should be Paid ?";
            this.checkBoxPayment.UseVisualStyleBackColor = true;
            this.checkBoxPayment.CheckedChanged += new System.EventHandler(this.checkBoxPayment_CheckedChanged);
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(274, 15);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActive.TabIndex = 3;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            this.checkBoxActive.CheckedChanged += new System.EventHandler(this.checkBoxActive_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(77, 13);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(176, 20);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.Location = new System.Drawing.Point(8, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 295);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // grid
            // 
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridCode,
            this.gridDescription,
            this.gridPayment,
            this.gridSeparation,
            this.gridReinstatement,
            this.gridActive,
            this.gridUserID});
            this.grid.Location = new System.Drawing.Point(4, 16);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(516, 284);
            this.grid.TabIndex = 0;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.Visible = false;
            // 
            // gridCode
            // 
            this.gridCode.FillWeight = 118.2856F;
            this.gridCode.HeaderText = "Code";
            this.gridCode.Name = "gridCode";
            // 
            // gridDescription
            // 
            this.gridDescription.FillWeight = 245.5241F;
            this.gridDescription.HeaderText = "Description";
            this.gridDescription.Name = "gridDescription";
            // 
            // gridPayment
            // 
            this.gridPayment.FillWeight = 52.67199F;
            this.gridPayment.HeaderText = "Should be Paid?";
            this.gridPayment.Name = "gridPayment";
            this.gridPayment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPayment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridSeparation
            // 
            this.gridSeparation.FillWeight = 58.61947F;
            this.gridSeparation.HeaderText = "Cause Separation";
            this.gridSeparation.Name = "gridSeparation";
            // 
            // gridReinstatement
            // 
            this.gridReinstatement.FillWeight = 63.9851F;
            this.gridReinstatement.HeaderText = "For Reinstatement";
            this.gridReinstatement.Name = "gridReinstatement";
            this.gridReinstatement.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReinstatement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridActive
            // 
            this.gridActive.FalseValue = "false";
            this.gridActive.FillWeight = 60.9137F;
            this.gridActive.HeaderText = "Active";
            this.gridActive.Name = "gridActive";
            this.gridActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridActive.TrueValue = "true";
            // 
            // gridUserID
            // 
            this.gridUserID.HeaderText = "UserID";
            this.gridUserID.Name = "gridUserID";
            this.gridUserID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(1, 410);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 36);
            this.panel2.TabIndex = 21;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(349, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(268, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(187, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(106, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 243.6548F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 277;
            // 
            // SanctionTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 447);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "SanctionTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanction Type Form";
            this.Load += new System.EventHandler(this.SanctionTypeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.CheckBox checkBoxSeparation;
        private System.Windows.Forms.CheckBox checkBoxPayment;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.CheckBox checkBoxReinstatement;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridPayment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridSeparation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridReinstatement;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridUserID;
    }
}