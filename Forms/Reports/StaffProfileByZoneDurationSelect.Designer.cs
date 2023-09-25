namespace eMAS.Forms.Reports
{
    partial class StaffProfileByZoneDurationSelect
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
            this.label5 = new System.Windows.Forms.Label();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.asAtDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.betweenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.andNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.betweenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.andNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboZone);
            this.panel1.Controls.Add(this.asAtDatePicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.betweenNumericUpDown);
            this.panel1.Controls.Add(this.andNumericUpDown);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 152);
            this.panel1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Zone:";
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Location = new System.Drawing.Point(74, 16);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(183, 21);
            this.cboZone.TabIndex = 25;
            this.cboZone.DropDown += new System.EventHandler(this.cboZone_DropDown);
            // 
            // asAtDatePicker
            // 
            this.asAtDatePicker.CustomFormat = " dd/MM/yyyy";
            this.asAtDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.asAtDatePicker.Location = new System.Drawing.Point(74, 109);
            this.asAtDatePicker.Name = "asAtDatePicker";
            this.asAtDatePicker.ShowCheckBox = true;
            this.asAtDatePicker.Size = new System.Drawing.Size(163, 20);
            this.asAtDatePicker.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "And";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Between";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "AsAtDate:";
            // 
            // betweenNumericUpDown
            // 
            this.betweenNumericUpDown.Location = new System.Drawing.Point(74, 46);
            this.betweenNumericUpDown.Name = "betweenNumericUpDown";
            this.betweenNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.betweenNumericUpDown.TabIndex = 0;
            // 
            // andNumericUpDown
            // 
            this.andNumericUpDown.Location = new System.Drawing.Point(74, 78);
            this.andNumericUpDown.Name = "andNumericUpDown";
            this.andNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.andNumericUpDown.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(50, 181);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 24);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(171, 181);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(111, 181);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 24);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // StaffProfileByZoneDurationSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(297, 230);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "StaffProfileByZoneDurationSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Profile By Zone Duration";
            this.Load += new System.EventHandler(this.StaffProfileByZoneDurationSelect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.betweenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.andNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker asAtDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown betweenNumericUpDown;
        private System.Windows.Forms.NumericUpDown andNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
    }
}