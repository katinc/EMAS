namespace eMAS.Forms.EmployeeManagement
{
    partial class GeneralReversalIncrementForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.numericPercentageIncrease = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cboGrade = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGradeCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerIncrementDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 37);
            this.panel1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "General Reversal Salary Increment";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Increase:";
            // 
            // numericPercentageIncrease
            // 
            this.numericPercentageIncrease.Location = new System.Drawing.Point(119, 149);
            this.numericPercentageIncrease.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericPercentageIncrease.Name = "numericPercentageIncrease";
            this.numericPercentageIncrease.Size = new System.Drawing.Size(78, 20);
            this.numericPercentageIncrease.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Grade:";
            // 
            // cboGrade
            // 
            this.cboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrade.FormattingEnabled = true;
            this.cboGrade.Location = new System.Drawing.Point(119, 97);
            this.cboGrade.Name = "cboGrade";
            this.cboGrade.Size = new System.Drawing.Size(182, 21);
            this.cboGrade.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Grade Category:";
            // 
            // cboGradeCategory
            // 
            this.cboGradeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeCategory.FormattingEnabled = true;
            this.cboGradeCategory.Location = new System.Drawing.Point(119, 70);
            this.cboGradeCategory.Name = "cboGradeCategory";
            this.cboGradeCategory.Size = new System.Drawing.Size(182, 21);
            this.cboGradeCategory.TabIndex = 45;
            this.cboGradeCategory.DropDown += new System.EventHandler(this.cboGradeCategory_DropDown);
            this.cboGradeCategory.SelectionChangeCommitted += new System.EventHandler(this.cboGradeCategory_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Increment Date:";
            // 
            // datePickerIncrementDate
            // 
            this.datePickerIncrementDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerIncrementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerIncrementDate.Location = new System.Drawing.Point(119, 45);
            this.datePickerIncrementDate.Name = "datePickerIncrementDate";
            this.datePickerIncrementDate.ShowCheckBox = true;
            this.datePickerIncrementDate.Size = new System.Drawing.Size(131, 20);
            this.datePickerIncrementDate.TabIndex = 43;
            this.datePickerIncrementDate.Value = new System.DateTime(2014, 9, 25, 0, 0, 0, 0);
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
            this.panel2.Location = new System.Drawing.Point(-1, 225);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 39);
            this.panel2.TabIndex = 51;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(247, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(60, 23);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(313, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(181, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(115, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkBoxPercentage
            // 
            this.checkBoxPercentage.AutoSize = true;
            this.checkBoxPercentage.Location = new System.Drawing.Point(119, 124);
            this.checkBoxPercentage.Name = "checkBoxPercentage";
            this.checkBoxPercentage.Size = new System.Drawing.Size(81, 17);
            this.checkBoxPercentage.TabIndex = 52;
            this.checkBoxPercentage.Text = "Percentage";
            this.checkBoxPercentage.UseVisualStyleBackColor = true;
            this.checkBoxPercentage.CheckedChanged += new System.EventHandler(this.checkBoxPercentage_CheckedChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(203, 151);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(21, 17);
            this.lblPercent.TabIndex = 53;
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
            this.label5.Location = new System.Drawing.Point(63, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(119, 171);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(122, 48);
            this.txtReason.TabIndex = 54;
            // 
            // GeneralReversalIncrementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 264);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.checkBoxPercentage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericPercentageIncrease);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboGrade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboGradeCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePickerIncrementDate);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "GeneralReversalIncrementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Reversal Salary Increment";
            this.Load += new System.EventHandler(this.GeneralReversalIncrementForm_Load);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericPercentageIncrease;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboGrade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGradeCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerIncrementDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkBoxPercentage;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReason;
    }
}