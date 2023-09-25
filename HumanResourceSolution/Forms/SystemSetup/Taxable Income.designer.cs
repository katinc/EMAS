namespace eMAS.All_UIs.System_SetupFORMS
{
    partial class Taxable_Income
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.viewbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.descriptionTextBox = new System.Windows.Forms.ComboBox();
            this.yearTextBox = new System.Windows.Forms.ComboBox();
            this.taxRateTextBox = new System.Windows.Forms.TextBox();
            this.annualTaxTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.yearErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.descriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.annualTaxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.taxRateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.annualTaxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRateErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 40);
            this.panel2.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(19, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Taxable Income";
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(328, 7);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(64, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // viewbtn
            // 
            this.viewbtn.Location = new System.Drawing.Point(256, 7);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(64, 23);
            this.viewbtn.TabIndex = 1;
            this.viewbtn.Text = "View";
            this.viewbtn.UseVisualStyleBackColor = true;
            this.viewbtn.Click += new System.EventHandler(this.viewbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxActive);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.yearTextBox);
            this.groupBox1.Controls.Add(this.taxRateTextBox);
            this.groupBox1.Controls.Add(this.annualTaxTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 117);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.descriptionTextBox.FormattingEnabled = true;
            this.descriptionTextBox.Location = new System.Drawing.Point(80, 61);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(110, 21);
            this.descriptionTextBox.TabIndex = 12;
            // 
            // yearTextBox
            // 
            this.yearTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearTextBox.FormattingEnabled = true;
            this.yearTextBox.Location = new System.Drawing.Point(80, 27);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(110, 21);
            this.yearTextBox.TabIndex = 11;
            // 
            // taxRateTextBox
            // 
            this.taxRateTextBox.Location = new System.Drawing.Point(334, 61);
            this.taxRateTextBox.Name = "taxRateTextBox";
            this.taxRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.taxRateTextBox.TabIndex = 8;
            this.taxRateTextBox.TextChanged += new System.EventHandler(this.taxRateTextBox_TextChanged);
            // 
            // annualTaxTextBox
            // 
            this.annualTaxTextBox.Location = new System.Drawing.Point(334, 31);
            this.annualTaxTextBox.Name = "annualTaxTextBox";
            this.annualTaxTextBox.Size = new System.Drawing.Size(100, 20);
            this.annualTaxTextBox.TabIndex = 7;
            this.annualTaxTextBox.TextChanged += new System.EventHandler(this.annualTaxTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tax Rate (%)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Annual Taxable Income";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Year";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.viewbtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(0, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 39);
            this.panel1.TabIndex = 24;
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(186, 7);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(64, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(116, 7);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(64, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // yearErrorProvider
            // 
            this.yearErrorProvider.ContainerControl = this;
            // 
            // descriptionErrorProvider
            // 
            this.descriptionErrorProvider.ContainerControl = this;
            // 
            // annualTaxErrorProvider
            // 
            this.annualTaxErrorProvider.ContainerControl = this;
            // 
            // taxRateErrorProvider
            // 
            this.taxRateErrorProvider.ContainerControl = this;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(80, 93);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActive.TabIndex = 13;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // Taxable_Income
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(488, 217);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Taxable_Income";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taxable Income Setup";
            this.Load += new System.EventHandler(this.Taxable_Income_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yearErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.annualTaxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxRateErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button viewbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox annualTaxTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox taxRateTextBox;
        private System.Windows.Forms.ErrorProvider yearErrorProvider;
        private System.Windows.Forms.ErrorProvider descriptionErrorProvider;
        private System.Windows.Forms.ErrorProvider annualTaxErrorProvider;
        private System.Windows.Forms.ErrorProvider taxRateErrorProvider;
        private System.Windows.Forms.ComboBox descriptionTextBox;
        private System.Windows.Forms.ComboBox yearTextBox;
        private System.Windows.Forms.CheckBox checkBoxActive;
    }
}