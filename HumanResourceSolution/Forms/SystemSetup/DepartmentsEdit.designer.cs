namespace eMAS.All_UIs.System_SetupFORMS
{
    partial class DepartmentsEdit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMinStaff = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxStaff = new System.Windows.Forms.NumericUpDown();
            this.chkInUse = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.maxStaffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.descriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.departmentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.minErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStaffErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMinStaff);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nameComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaxStaff);
            this.groupBox1.Controls.Add(this.chkInUse);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 162);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // txtMinStaff
            // 
            this.txtMinStaff.Location = new System.Drawing.Point(91, 78);
            this.txtMinStaff.Name = "txtMinStaff";
            this.txtMinStaff.Size = new System.Drawing.Size(78, 20);
            this.txtMinStaff.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "Min Staff:";
            // 
            // nameComboBox
            // 
            this.nameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(91, 55);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(155, 21);
            this.nameComboBox.TabIndex = 21;
            this.nameComboBox.DropDown += new System.EventHandler(this.nameComboBox_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "Supervisor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "Active:";
            // 
            // txtMaxStaff
            // 
            this.txtMaxStaff.Location = new System.Drawing.Point(91, 101);
            this.txtMaxStaff.Name = "txtMaxStaff";
            this.txtMaxStaff.Size = new System.Drawing.Size(61, 20);
            this.txtMaxStaff.TabIndex = 14;
            // 
            // chkInUse
            // 
            this.chkInUse.AutoSize = true;
            this.chkInUse.Checked = true;
            this.chkInUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInUse.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInUse.Location = new System.Drawing.Point(91, 127);
            this.chkInUse.Name = "chkInUse";
            this.chkInUse.Size = new System.Drawing.Size(15, 14);
            this.chkInUse.TabIndex = 13;
            this.chkInUse.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(91, 32);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(155, 20);
            this.txtDescription.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Max Staff:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description:";
            // 
            // closebtn
            // 
            this.closebtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(280, 66);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(64, 23);
            this.closebtn.TabIndex = 8;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(280, 36);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(64, 23);
            this.savebtn.TabIndex = 7;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // maxStaffErrorProvider
            // 
            this.maxStaffErrorProvider.ContainerControl = this;
            // 
            // descriptionErrorProvider
            // 
            this.descriptionErrorProvider.ContainerControl = this;
            // 
            // departmentErrorProvider
            // 
            this.departmentErrorProvider.ContainerControl = this;
            // 
            // minErrorProvider
            // 
            this.minErrorProvider.ContainerControl = this;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(91, 9);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(155, 20);
            this.txtCode.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.TabIndex = 24;
            this.label6.Text = "Code:";
            // 
            // DepartmentsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(351, 171);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.savebtn);
            this.Name = "DepartmentsEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DepartmentEdit";
            this.Load += new System.EventHandler(this.DepartmentsEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStaffErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtMaxStaff;
        private System.Windows.Forms.CheckBox chkInUse;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ErrorProvider maxStaffErrorProvider;
        private System.Windows.Forms.ErrorProvider descriptionErrorProvider;
        private System.Windows.Forms.ErrorProvider departmentErrorProvider;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtMinStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider minErrorProvider;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label6;
    }
}