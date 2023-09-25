namespace eMAS.Forms.Reports
{
    partial class IncomeTaxReturnsSelect
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.periodLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMechanised = new System.Windows.Forms.Label();
            this.cboMechanised = new System.Windows.Forms.ComboBox();
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(183, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(54, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(243, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(54, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(303, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(250, 43);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(96, 21);
            this.yearComboBox.TabIndex = 5;
            this.yearComboBox.DropDown += new System.EventHandler(this.yearComboBox_DropDown);
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(75, 42);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(120, 21);
            this.monthComboBox.TabIndex = 4;
            this.monthComboBox.DropDown += new System.EventHandler(this.monthComboBox_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year :";
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Location = new System.Drawing.Point(28, 46);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(43, 13);
            this.periodLabel.TabIndex = 2;
            this.periodLabel.Text = "Month :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 33);
            this.panel2.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(8, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(245, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Income Tax Returns Report Customization";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 33);
            this.panel1.TabIndex = 24;
            // 
            // lblMechanised
            // 
            this.lblMechanised.AutoSize = true;
            this.lblMechanised.Location = new System.Drawing.Point(4, 73);
            this.lblMechanised.Name = "lblMechanised";
            this.lblMechanised.Size = new System.Drawing.Size(68, 13);
            this.lblMechanised.TabIndex = 91;
            this.lblMechanised.Text = "Mechanised:";
            // 
            // cboMechanised
            // 
            this.cboMechanised.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMechanised.FormattingEnabled = true;
            this.cboMechanised.Location = new System.Drawing.Point(75, 69);
            this.cboMechanised.Name = "cboMechanised";
            this.cboMechanised.Size = new System.Drawing.Size(121, 21);
            this.cboMechanised.TabIndex = 90;
            this.cboMechanised.DropDown += new System.EventHandler(this.cboMechanised_DropDown);
            this.cboMechanised.SelectedIndexChanged += new System.EventHandler(this.cboMechanised_SelectedIndexChanged);
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // IncomeTaxReturnsSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(366, 159);
            this.Controls.Add(this.lblMechanised);
            this.Controls.Add(this.cboMechanised);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.periodLabel);
            this.MaximizeBox = false;
            this.Name = "IncomeTaxReturnsSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Income Tax Returns Report Customization";
            this.Load += new System.EventHandler(this.IncomeTaxReturnsSelect_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.Label lblMechanised;
        private System.Windows.Forms.ComboBox cboMechanised;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
    }
}