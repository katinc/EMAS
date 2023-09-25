namespace eMAS.Forms.Reports
{
    partial class StaffListByLengthOfServiceSelect
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
            this.betweenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.andNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.asAtDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.betweenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.andNumericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // betweenNumericUpDown
            // 
            this.betweenNumericUpDown.Location = new System.Drawing.Point(74, 26);
            this.betweenNumericUpDown.Name = "betweenNumericUpDown";
            this.betweenNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.betweenNumericUpDown.TabIndex = 0;
            // 
            // andNumericUpDown
            // 
            this.andNumericUpDown.Location = new System.Drawing.Point(74, 58);
            this.andNumericUpDown.Name = "andNumericUpDown";
            this.andNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.andNumericUpDown.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.asAtDatePicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.betweenNumericUpDown);
            this.panel1.Controls.Add(this.andNumericUpDown);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 121);
            this.panel1.TabIndex = 3;
            // 
            // asAtDatePicker
            // 
            this.asAtDatePicker.CustomFormat = " dd/MM/yyyy";
            this.asAtDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.asAtDatePicker.Location = new System.Drawing.Point(74, 85);
            this.asAtDatePicker.Name = "asAtDatePicker";
            this.asAtDatePicker.ShowCheckBox = true;
            this.asAtDatePicker.Size = new System.Drawing.Size(163, 20);
            this.asAtDatePicker.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "And";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Between";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "AsAtDate:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(186, 160);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(105, 160);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(24, 160);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // StaffListByLengthOfServiceSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(284, 202);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panel1);
            this.Name = "StaffListByLengthOfServiceSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff List By Length Of Service";
            this.Load += new System.EventHandler(this.StaffListByLengthOfServiceSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.betweenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.andNumericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown betweenNumericUpDown;
        private System.Windows.Forms.NumericUpDown andNumericUpDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DateTimePicker asAtDatePicker;
    }
}