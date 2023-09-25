namespace eMAS.Forms.EmployeeManagement
{
    partial class GeneralIncrementForm
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
            this.label8 = new System.Windows.Forms.Label();
            this.datePickerIncrementDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericPercentageIncrease = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxPercentage = new System.Windows.Forms.CheckBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPercentageIncrease)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 37);
            this.panel1.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "General Salary Increment";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datePickerIncrementDate
            // 
            this.datePickerIncrementDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerIncrementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerIncrementDate.Location = new System.Drawing.Point(110, 42);
            this.datePickerIncrementDate.Name = "datePickerIncrementDate";
            this.datePickerIncrementDate.ShowCheckBox = true;
            this.datePickerIncrementDate.Size = new System.Drawing.Size(182, 20);
            this.datePickerIncrementDate.TabIndex = 17;
            this.datePickerIncrementDate.Value = new System.DateTime(2014, 9, 24, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Increment Date:";
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(110, 67);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(182, 21);
            this.cboGradeCategory.TabIndex = 19;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Grade Category:";
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(110, 94);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(182, 21);
            this.cboGrade.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Grade:";
            // 
            // numericPercentageIncrease
            // 
            this.numericPercentageIncrease.Location = new System.Drawing.Point(110, 144);
            this.numericPercentageIncrease.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericPercentageIncrease.Name = "numericPercentageIncrease";
            this.numericPercentageIncrease.Size = new System.Drawing.Size(78, 20);
            this.numericPercentageIncrease.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(-2, 233);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 32);
            this.panel2.TabIndex = 41;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(176, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(60, 23);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(242, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(110, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(44, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Increase:";
            // 
            // checkBoxPercentage
            // 
            this.checkBoxPercentage.AutoSize = true;
            this.checkBoxPercentage.Location = new System.Drawing.Point(111, 121);
            this.checkBoxPercentage.Name = "checkBoxPercentage";
            this.checkBoxPercentage.Size = new System.Drawing.Size(81, 17);
            this.checkBoxPercentage.TabIndex = 43;
            this.checkBoxPercentage.Text = "Percentage";
            this.checkBoxPercentage.UseVisualStyleBackColor = true;
            this.checkBoxPercentage.CheckedChanged += new System.EventHandler(this.checkBoxPercentage_CheckedChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(194, 146);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(21, 17);
            this.lblPercent.TabIndex = 44;
            this.lblPercent.Text = "%";
            this.lblPercent.Visible = false;
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(109, 169);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(183, 48);
            this.txtReason.TabIndex = 45;
            // 
            // GeneralIncrementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 265);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.checkBoxPercentage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.numericPercentageIncrease);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboGrade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboGradeCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePickerIncrementDate);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "GeneralIncrementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Salary Increment";
            this.Load += new System.EventHandler(this.GeneralIncrementForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPercentageIncrease)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datePickerIncrementDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericPercentageIncrease;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxPercentage;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReason;
    }
}