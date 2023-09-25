namespace eMAS.All_UIs.System_SetupFORMS
{
    partial class DepartmentsNew
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
            this.closebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinStaff = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxStaff = new System.Windows.Forms.NumericUpDown();
            this.chkInUse = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.departmentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.descriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.maxStaffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.minErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.supervisorErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStaffErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supervisorErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // closebtn
            // 
            this.closebtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(280, 82);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(64, 23);
            this.closebtn.TabIndex = 5;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(280, 52);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(64, 23);
            this.savebtn.TabIndex = 4;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nameComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMinStaff);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaxStaff);
            this.groupBox1.Controls.Add(this.chkInUse);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 152);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(90, 7);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(155, 20);
            this.txtCode.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 14);
            this.label6.TabIndex = 26;
            this.label6.Text = "Code:";
            // 
            // nameComboBox
            // 
            this.nameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(90, 56);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(155, 21);
            this.nameComboBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Supervisor:";
            // 
            // txtMinStaff
            // 
            this.txtMinStaff.Location = new System.Drawing.Point(90, 83);
            this.txtMinStaff.Name = "txtMinStaff";
            this.txtMinStaff.Size = new System.Drawing.Size(78, 20);
            this.txtMinStaff.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Max Staff:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "Active:";
            // 
            // txtMaxStaff
            // 
            this.txtMaxStaff.Location = new System.Drawing.Point(90, 109);
            this.txtMaxStaff.Name = "txtMaxStaff";
            this.txtMaxStaff.Size = new System.Drawing.Size(78, 20);
            this.txtMaxStaff.TabIndex = 14;
            this.txtMaxStaff.ValueChanged += new System.EventHandler(this.txtMaxStaff_ValueChanged);
            // 
            // chkInUse
            // 
            this.chkInUse.AutoSize = true;
            this.chkInUse.Checked = true;
            this.chkInUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInUse.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInUse.Location = new System.Drawing.Point(90, 134);
            this.chkInUse.Name = "chkInUse";
            this.chkInUse.Size = new System.Drawing.Size(15, 14);
            this.chkInUse.TabIndex = 13;
            this.chkInUse.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(90, 31);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(155, 20);
            this.txtDescription.TabIndex = 12;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Min Staff:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description:";
            // 
            // departmentErrorProvider
            // 
            this.departmentErrorProvider.ContainerControl = this;
            // 
            // descriptionErrorProvider
            // 
            this.descriptionErrorProvider.ContainerControl = this;
            // 
            // maxStaffErrorProvider
            // 
            this.maxStaffErrorProvider.ContainerControl = this;
            // 
            // minErrorProvider
            // 
            this.minErrorProvider.ContainerControl = this;
            // 
            // supervisorErrorProvider
            // 
            this.supervisorErrorProvider.ContainerControl = this;
            // 
            // DepartmentsNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(351, 167);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.savebtn);
            this.MaximizeBox = false;
            this.Name = "DepartmentsNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Department Maintenance";
            this.Load += new System.EventHandler(this.DepartmentsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStaffErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supervisorErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtMaxStaff;
        private System.Windows.Forms.CheckBox chkInUse;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider departmentErrorProvider;
        private System.Windows.Forms.ErrorProvider descriptionErrorProvider;
        private System.Windows.Forms.ErrorProvider maxStaffErrorProvider;
        private System.Windows.Forms.NumericUpDown txtMinStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider minErrorProvider;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider supervisorErrorProvider;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label6;
    }
}