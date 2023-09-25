namespace eMAS.All_UIs.System_SetupFORMS
{
    partial class Deduction_SetupEdit
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.rateBasedRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.inactivechkBox = new System.Windows.Forms.CheckBox();
            this.fixedAmountRadioButton = new System.Windows.Forms.RadioButton();
            this.fixedAmountTextBox = new System.Windows.Forms.TextBox();
            this.Level = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rateNud = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.calculatedOncmb = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.typecmb = new System.Windows.Forms.ComboBox();
            this.descriptiontxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.deductionTypeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.descriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.deductionCategoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.calculatedOnErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.rateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fixedAmountErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateNud)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deductionTypeErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deductionCategoryErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculatedOnErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedAmountErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtCode);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.rateBasedRadioButton);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.inactivechkBox);
            this.panel3.Controls.Add(this.fixedAmountRadioButton);
            this.panel3.Controls.Add(this.fixedAmountTextBox);
            this.panel3.Controls.Add(this.Level);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.typecmb);
            this.panel3.Controls.Add(this.descriptiontxt);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(528, 184);
            this.panel3.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rateBasedRadioButton
            // 
            this.rateBasedRadioButton.AutoSize = true;
            this.rateBasedRadioButton.Location = new System.Drawing.Point(274, 62);
            this.rateBasedRadioButton.Name = "rateBasedRadioButton";
            this.rateBasedRadioButton.Size = new System.Drawing.Size(81, 17);
            this.rateBasedRadioButton.TabIndex = 33;
            this.rateBasedRadioButton.Text = "Rate Based";
            this.rateBasedRadioButton.UseVisualStyleBackColor = true;
            this.rateBasedRadioButton.CheckedChanged += new System.EventHandler(this.rateBasedRadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Active:";
            // 
            // inactivechkBox
            // 
            this.inactivechkBox.AutoSize = true;
            this.inactivechkBox.Location = new System.Drawing.Point(92, 111);
            this.inactivechkBox.Name = "inactivechkBox";
            this.inactivechkBox.Size = new System.Drawing.Size(15, 14);
            this.inactivechkBox.TabIndex = 20;
            this.inactivechkBox.UseVisualStyleBackColor = true;
            // 
            // fixedAmountRadioButton
            // 
            this.fixedAmountRadioButton.AutoSize = true;
            this.fixedAmountRadioButton.Checked = true;
            this.fixedAmountRadioButton.Location = new System.Drawing.Point(274, 37);
            this.fixedAmountRadioButton.Name = "fixedAmountRadioButton";
            this.fixedAmountRadioButton.Size = new System.Drawing.Size(89, 17);
            this.fixedAmountRadioButton.TabIndex = 32;
            this.fixedAmountRadioButton.TabStop = true;
            this.fixedAmountRadioButton.Text = "Fixed Amount";
            this.fixedAmountRadioButton.UseVisualStyleBackColor = true;
            this.fixedAmountRadioButton.CheckedChanged += new System.EventHandler(this.fixedAmountRadioButton_CheckedChanged);
            // 
            // fixedAmountTextBox
            // 
            this.fixedAmountTextBox.Location = new System.Drawing.Point(371, 36);
            this.fixedAmountTextBox.Name = "fixedAmountTextBox";
            this.fixedAmountTextBox.Size = new System.Drawing.Size(75, 20);
            this.fixedAmountTextBox.TabIndex = 31;
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.Location = new System.Drawing.Point(26, 88);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(63, 13);
            this.Level.TabIndex = 18;
            this.Level.Text = "Description:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rateNud);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.calculatedOncmb);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(274, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 65);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // rateNud
            // 
            this.rateNud.Location = new System.Drawing.Point(98, 12);
            this.rateNud.Name = "rateNud";
            this.rateNud.Size = new System.Drawing.Size(66, 20);
            this.rateNud.TabIndex = 22;
            this.rateNud.ValueChanged += new System.EventHandler(this.rateNud_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Rate(%)";
            // 
            // calculatedOncmb
            // 
            this.calculatedOncmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calculatedOncmb.FormattingEnabled = true;
            this.calculatedOncmb.Location = new System.Drawing.Point(98, 35);
            this.calculatedOncmb.Name = "calculatedOncmb";
            this.calculatedOncmb.Size = new System.Drawing.Size(117, 21);
            this.calculatedOncmb.TabIndex = 19;
            this.calculatedOncmb.SelectedIndexChanged += new System.EventHandler(this.calculatedOncmb_SelectedIndexChanged);
            this.calculatedOncmb.DropDown += new System.EventHandler(this.calculatedOncmb_DropDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Calculated On:";
            // 
            // typecmb
            // 
            this.typecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typecmb.FormattingEnabled = true;
            this.typecmb.Location = new System.Drawing.Point(92, 35);
            this.typecmb.Name = "typecmb";
            this.typecmb.Size = new System.Drawing.Size(130, 21);
            this.typecmb.TabIndex = 19;
            this.typecmb.SelectedIndexChanged += new System.EventHandler(this.typecmb_SelectedIndexChanged);
            this.typecmb.DropDown += new System.EventHandler(this.typecmb_DropDown);
            // 
            // descriptiontxt
            // 
            this.descriptiontxt.Location = new System.Drawing.Point(92, 85);
            this.descriptiontxt.Name = "descriptiontxt";
            this.descriptiontxt.Size = new System.Drawing.Size(168, 20);
            this.descriptiontxt.TabIndex = 2;
            this.descriptiontxt.TextChanged += new System.EventHandler(this.descriptiontxt_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Type:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 40);
            this.panel2.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Deduction Setup";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(0, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 33);
            this.panel1.TabIndex = 24;
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(453, 5);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(64, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(383, 5);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(64, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(313, 5);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(64, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // deductionTypeErrorProvider
            // 
            this.deductionTypeErrorProvider.ContainerControl = this;
            // 
            // descriptionErrorProvider
            // 
            this.descriptionErrorProvider.ContainerControl = this;
            // 
            // deductionCategoryErrorProvider
            // 
            this.deductionCategoryErrorProvider.ContainerControl = this;
            // 
            // calculatedOnErrorProvider
            // 
            this.calculatedOnErrorProvider.ContainerControl = this;
            // 
            // rateErrorProvider
            // 
            this.rateErrorProvider.ContainerControl = this;
            // 
            // fixedAmountErrorProvider
            // 
            this.fixedAmountErrorProvider.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Code:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(92, 61);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(94, 20);
            this.txtCode.TabIndex = 35;
            // 
            // Deduction_SetupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(524, 252);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Deduction_SetupEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deduction_SetupEdit";
            this.Load += new System.EventHandler(this.Deduction_Setup_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateNud)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deductionTypeErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deductionCategoryErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculatedOnErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedAmountErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown rateNud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox inactivechkBox;
        private System.Windows.Forms.Label Level;
        private System.Windows.Forms.ComboBox calculatedOncmb;
        private System.Windows.Forms.ComboBox typecmb;
        private System.Windows.Forms.TextBox descriptiontxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ErrorProvider deductionTypeErrorProvider;
        private System.Windows.Forms.ErrorProvider descriptionErrorProvider;
        private System.Windows.Forms.ErrorProvider deductionCategoryErrorProvider;
        private System.Windows.Forms.ErrorProvider calculatedOnErrorProvider;
        private System.Windows.Forms.ErrorProvider rateErrorProvider;
        private System.Windows.Forms.RadioButton rateBasedRadioButton;
        private System.Windows.Forms.RadioButton fixedAmountRadioButton;
        private System.Windows.Forms.TextBox fixedAmountTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider fixedAmountErrorProvider;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCode;
    }
}