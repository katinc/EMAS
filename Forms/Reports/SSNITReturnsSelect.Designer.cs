namespace eMAS.Forms.Reports
{
    partial class SSNITReturnsSelect
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.lblMechanised = new System.Windows.Forms.Label();
            this.cboMechanised = new System.Windows.Forms.ComboBox();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.periodLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.allProvidentRadioButton = new System.Windows.Forms.RadioButton();
            this.employerProvidentRadioButton = new System.Windows.Forms.RadioButton();
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.employeeProvidentRadioButton = new System.Windows.Forms.RadioButton();
            this.employerRadioButton = new System.Windows.Forms.RadioButton();
            this.employeeRadioButton = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 37);
            this.panel1.TabIndex = 30;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(218, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(98, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(54, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(158, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 33);
            this.panel2.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(294, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "SSNIT/PROVIDENT Returns Report Customization";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboFormat);
            this.groupBox1.Controls.Add(this.lblMechanised);
            this.groupBox1.Controls.Add(this.cboMechanised);
            this.groupBox1.Controls.Add(this.yearComboBox);
            this.groupBox1.Controls.Add(this.monthComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.periodLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 67);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "Format:";
            // 
            // cboFormat
            // 
            this.cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormat.FormattingEnabled = true;
            this.cboFormat.Items.AddRange(new object[] {
            "Name Separated",
            "Name Joined"});
            this.cboFormat.Location = new System.Drawing.Point(248, 41);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(125, 21);
            this.cboFormat.TabIndex = 92;
            // 
            // lblMechanised
            // 
            this.lblMechanised.AutoSize = true;
            this.lblMechanised.Location = new System.Drawing.Point(5, 44);
            this.lblMechanised.Name = "lblMechanised";
            this.lblMechanised.Size = new System.Drawing.Size(68, 13);
            this.lblMechanised.TabIndex = 91;
            this.lblMechanised.Text = "Mechanised:";
            // 
            // cboMechanised
            // 
            this.cboMechanised.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMechanised.FormattingEnabled = true;
            this.cboMechanised.Location = new System.Drawing.Point(76, 40);
            this.cboMechanised.Name = "cboMechanised";
            this.cboMechanised.Size = new System.Drawing.Size(121, 21);
            this.cboMechanised.TabIndex = 90;
            this.cboMechanised.DropDown += new System.EventHandler(this.cboMechanised_DropDown);
            this.cboMechanised.SelectedIndexChanged += new System.EventHandler(this.cboMechanised_SelectedIndexChanged);
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(248, 16);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(123, 21);
            this.yearComboBox.TabIndex = 5;
            this.yearComboBox.DropDown += new System.EventHandler(this.yearComboBox_DropDown);
            this.yearComboBox.SelectedIndexChanged += new System.EventHandler(this.yearComboBox_SelectedIndexChanged);
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(76, 15);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(121, 21);
            this.monthComboBox.TabIndex = 4;
            this.monthComboBox.DropDown += new System.EventHandler(this.monthComboBox_DropDown);
            this.monthComboBox.SelectedIndexChanged += new System.EventHandler(this.monthComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year :";
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Location = new System.Drawing.Point(30, 19);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(43, 13);
            this.periodLabel.TabIndex = 2;
            this.periodLabel.Text = "Month :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.allProvidentRadioButton);
            this.groupBox2.Controls.Add(this.employerProvidentRadioButton);
            this.groupBox2.Controls.Add(this.allRadioButton);
            this.groupBox2.Controls.Add(this.employeeProvidentRadioButton);
            this.groupBox2.Controls.Add(this.employerRadioButton);
            this.groupBox2.Controls.Add(this.employeeRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 84);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SSNIT / PROVIDENT";
            this.groupBox2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "PROVIDENT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "SSNIT:";
            // 
            // allProvidentRadioButton
            // 
            this.allProvidentRadioButton.AutoSize = true;
            this.allProvidentRadioButton.Location = new System.Drawing.Point(272, 51);
            this.allProvidentRadioButton.Name = "allProvidentRadioButton";
            this.allProvidentRadioButton.Size = new System.Drawing.Size(36, 17);
            this.allProvidentRadioButton.TabIndex = 2;
            this.allProvidentRadioButton.TabStop = true;
            this.allProvidentRadioButton.Text = "All";
            this.allProvidentRadioButton.UseVisualStyleBackColor = true;
            // 
            // employerProvidentRadioButton
            // 
            this.employerProvidentRadioButton.AutoSize = true;
            this.employerProvidentRadioButton.Location = new System.Drawing.Point(179, 51);
            this.employerProvidentRadioButton.Name = "employerProvidentRadioButton";
            this.employerProvidentRadioButton.Size = new System.Drawing.Size(68, 17);
            this.employerProvidentRadioButton.TabIndex = 1;
            this.employerProvidentRadioButton.TabStop = true;
            this.employerProvidentRadioButton.Text = "Employer";
            this.employerProvidentRadioButton.UseVisualStyleBackColor = true;
            // 
            // allRadioButton
            // 
            this.allRadioButton.AutoSize = true;
            this.allRadioButton.Location = new System.Drawing.Point(272, 19);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(36, 17);
            this.allRadioButton.TabIndex = 2;
            this.allRadioButton.TabStop = true;
            this.allRadioButton.Text = "All";
            this.allRadioButton.UseVisualStyleBackColor = true;
            // 
            // employeeProvidentRadioButton
            // 
            this.employeeProvidentRadioButton.AutoSize = true;
            this.employeeProvidentRadioButton.Location = new System.Drawing.Point(82, 51);
            this.employeeProvidentRadioButton.Name = "employeeProvidentRadioButton";
            this.employeeProvidentRadioButton.Size = new System.Drawing.Size(76, 17);
            this.employeeProvidentRadioButton.TabIndex = 0;
            this.employeeProvidentRadioButton.TabStop = true;
            this.employeeProvidentRadioButton.Text = "Employees";
            this.employeeProvidentRadioButton.UseVisualStyleBackColor = true;
            // 
            // employerRadioButton
            // 
            this.employerRadioButton.AutoSize = true;
            this.employerRadioButton.Location = new System.Drawing.Point(179, 19);
            this.employerRadioButton.Name = "employerRadioButton";
            this.employerRadioButton.Size = new System.Drawing.Size(68, 17);
            this.employerRadioButton.TabIndex = 1;
            this.employerRadioButton.TabStop = true;
            this.employerRadioButton.Text = "Employer";
            this.employerRadioButton.UseVisualStyleBackColor = true;
            // 
            // employeeRadioButton
            // 
            this.employeeRadioButton.AutoSize = true;
            this.employeeRadioButton.Location = new System.Drawing.Point(82, 19);
            this.employeeRadioButton.Name = "employeeRadioButton";
            this.employeeRadioButton.Size = new System.Drawing.Size(76, 17);
            this.employeeRadioButton.TabIndex = 0;
            this.employeeRadioButton.TabStop = true;
            this.employeeRadioButton.Text = "Employees";
            this.employeeRadioButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SSNITReturnsSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(403, 259);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "SSNITReturnsSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSNIT / PROVIDENT Returns Report";
            this.Load += new System.EventHandler(this.SSNITReturnsSelect_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton employeeRadioButton;
        private System.Windows.Forms.RadioButton employerRadioButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RadioButton allRadioButton;
        private System.Windows.Forms.Label lblMechanised;
        private System.Windows.Forms.ComboBox cboMechanised;
        private System.Windows.Forms.RadioButton allProvidentRadioButton;
        private System.Windows.Forms.RadioButton employerProvidentRadioButton;
        private System.Windows.Forms.RadioButton employeeProvidentRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFormat;
    }
}