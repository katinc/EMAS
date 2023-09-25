
namespace eMAS.Forms.SystemSetup
{
    partial class FieldMapping
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
            this.cmbDataset = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSubDataset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDataElement = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbComboDataTable = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStaffDataTable = new System.Windows.Forms.ComboBox();
            this.cmbStaffDataView = new System.Windows.Forms.ComboBox();
            this.cmbStaffDataColumn = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbControlTypes = new System.Windows.Forms.ComboBox();
            this.btnClearD = new System.Windows.Forms.Button();
            this.cboMenuItem = new System.Windows.Forms.ComboBox();
            this.cboForm = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnUpdateMenuForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbDataset
            // 
            this.cmbDataset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataset.FormattingEnabled = true;
            this.cmbDataset.Location = new System.Drawing.Point(152, 66);
            this.cmbDataset.Name = "cmbDataset";
            this.cmbDataset.Size = new System.Drawing.Size(333, 21);
            this.cmbDataset.TabIndex = 0;
            this.cmbDataset.SelectionChangeCommitted += new System.EventHandler(this.cmbDataset_SelectionChangeCommitted);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(273, 321);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dataset";
            // 
            // cmbSubDataset
            // 
            this.cmbSubDataset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubDataset.FormattingEnabled = true;
            this.cmbSubDataset.Location = new System.Drawing.Point(152, 93);
            this.cmbSubDataset.Name = "cmbSubDataset";
            this.cmbSubDataset.Size = new System.Drawing.Size(333, 21);
            this.cmbSubDataset.TabIndex = 0;
            this.cmbSubDataset.SelectionChangeCommitted += new System.EventHandler(this.cmbSubDataset_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sub Dataset";
            // 
            // cmbDataElement
            // 
            this.cmbDataElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataElement.FormattingEnabled = true;
            this.cmbDataElement.Location = new System.Drawing.Point(152, 123);
            this.cmbDataElement.Name = "cmbDataElement";
            this.cmbDataElement.Size = new System.Drawing.Size(333, 21);
            this.cmbDataElement.TabIndex = 0;
            this.cmbDataElement.SelectionChangeCommitted += new System.EventHandler(this.cmbDataElement_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Element";
            // 
            // cmbDataType
            // 
            this.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(152, 159);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(333, 21);
            this.cmbDataType.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "DataType";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Control Type";
            // 
            // cmbComboDataTable
            // 
            this.cmbComboDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComboDataTable.FormattingEnabled = true;
            this.cmbComboDataTable.Location = new System.Drawing.Point(152, 213);
            this.cmbComboDataTable.Name = "cmbComboDataTable";
            this.cmbComboDataTable.Size = new System.Drawing.Size(333, 21);
            this.cmbComboDataTable.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Combo Data Table";
            // 
            // cmbStaffDataTable
            // 
            this.cmbStaffDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffDataTable.FormattingEnabled = true;
            this.cmbStaffDataTable.Location = new System.Drawing.Point(152, 240);
            this.cmbStaffDataTable.Name = "cmbStaffDataTable";
            this.cmbStaffDataTable.Size = new System.Drawing.Size(333, 21);
            this.cmbStaffDataTable.TabIndex = 0;
            this.cmbStaffDataTable.SelectedIndexChanged += new System.EventHandler(this.cmbStaffDataTable_SelectionChangeCommitted);
            // 
            // cmbStaffDataView
            // 
            this.cmbStaffDataView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffDataView.FormattingEnabled = true;
            this.cmbStaffDataView.Location = new System.Drawing.Point(152, 267);
            this.cmbStaffDataView.Name = "cmbStaffDataView";
            this.cmbStaffDataView.Size = new System.Drawing.Size(333, 21);
            this.cmbStaffDataView.TabIndex = 0;
            // 
            // cmbStaffDataColumn
            // 
            this.cmbStaffDataColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffDataColumn.FormattingEnabled = true;
            this.cmbStaffDataColumn.Location = new System.Drawing.Point(152, 294);
            this.cmbStaffDataColumn.Name = "cmbStaffDataColumn";
            this.cmbStaffDataColumn.Size = new System.Drawing.Size(333, 21);
            this.cmbStaffDataColumn.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Staff Data Table";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(65, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Staff Data View";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Staff Data Column";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(354, 321);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 26);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbControlTypes
            // 
            this.cmbControlTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbControlTypes.FormattingEnabled = true;
            this.cmbControlTypes.Location = new System.Drawing.Point(152, 186);
            this.cmbControlTypes.Name = "cmbControlTypes";
            this.cmbControlTypes.Size = new System.Drawing.Size(333, 21);
            this.cmbControlTypes.TabIndex = 0;
            // 
            // btnClearD
            // 
            this.btnClearD.Location = new System.Drawing.Point(192, 321);
            this.btnClearD.Name = "btnClearD";
            this.btnClearD.Size = new System.Drawing.Size(75, 26);
            this.btnClearD.TabIndex = 1;
            this.btnClearD.Text = "Clear Details";
            this.btnClearD.UseVisualStyleBackColor = true;
            this.btnClearD.Click += new System.EventHandler(this.btnClearD_Click);
            // 
            // cboMenuItem
            // 
            this.cboMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenuItem.FormattingEnabled = true;
            this.cboMenuItem.Location = new System.Drawing.Point(152, 410);
            this.cboMenuItem.Name = "cboMenuItem";
            this.cboMenuItem.Size = new System.Drawing.Size(333, 21);
            this.cboMenuItem.TabIndex = 0;
            // 
            // cboForm
            // 
            this.cboForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboForm.FormattingEnabled = true;
            this.cboForm.Location = new System.Drawing.Point(152, 437);
            this.cboForm.Name = "cboForm";
            this.cboForm.Size = new System.Drawing.Size(333, 21);
            this.cboForm.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 413);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Menu Item";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(89, 440);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Form ";
            // 
            // btnUpdateMenuForm
            // 
            this.btnUpdateMenuForm.Location = new System.Drawing.Point(273, 464);
            this.btnUpdateMenuForm.Name = "btnUpdateMenuForm";
            this.btnUpdateMenuForm.Size = new System.Drawing.Size(75, 26);
            this.btnUpdateMenuForm.TabIndex = 1;
            this.btnUpdateMenuForm.Text = "Update";
            this.btnUpdateMenuForm.UseVisualStyleBackColor = true;
            this.btnUpdateMenuForm.Click += new System.EventHandler(this.btnUpdateMenuForm_Click);
            // 
            // FieldMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 630);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDataElement);
            this.Controls.Add(this.btnClearD);
            this.Controls.Add(this.btnUpdateMenuForm);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbSubDataset);
            this.Controls.Add(this.cboForm);
            this.Controls.Add(this.cmbStaffDataColumn);
            this.Controls.Add(this.cmbControlTypes);
            this.Controls.Add(this.cboMenuItem);
            this.Controls.Add(this.cmbComboDataTable);
            this.Controls.Add(this.cmbStaffDataView);
            this.Controls.Add(this.cmbStaffDataTable);
            this.Controls.Add(this.cmbDataType);
            this.Controls.Add(this.cmbDataset);
            this.Name = "FieldMapping";
            this.Text = "FieldMapping";
            this.Load += new System.EventHandler(this.FieldMapping_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDataset;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSubDataset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDataElement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbControlType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbComboDataTable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStaffDataTable;
        private System.Windows.Forms.ComboBox cmbStaffDataView;
        private System.Windows.Forms.ComboBox cmbStaffDataColumn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbControlTypes;
        private System.Windows.Forms.Button btnClearD;
        private System.Windows.Forms.ComboBox cboMenuItem;
        private System.Windows.Forms.ComboBox cboForm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnUpdateMenuForm;
    }
}