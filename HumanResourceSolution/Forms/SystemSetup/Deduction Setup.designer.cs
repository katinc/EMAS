namespace eMAS.All_UIs.System_SetupFORMS
{
    partial class Deduction_Setup
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
            this.label1 = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.typecmb = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewbtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnType = new System.Windows.Forms.Button();
            this.rateBasedRadioButton = new System.Windows.Forms.RadioButton();
            this.fixedAmountRadioButton = new System.Windows.Forms.RadioButton();
            this.fixedAmountTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rateNud = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.calculatedOncmb = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inactivechkBox = new System.Windows.Forms.CheckBox();
            this.descriptiontxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.deductionTypeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.deductionCategoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.calculatedOnErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.rateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fixedAmountErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deductionTypeErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deductionCategoryErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculatedOnErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedAmountErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 31);
            this.panel2.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Deduction";
            // 
            // Level
            // 
            this.Level.AutoSize = true;
            this.Level.Location = new System.Drawing.Point(5, 88);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(63, 13);
            this.Level.TabIndex = 18;
            this.Level.Text = "Description:";
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(437, 6);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(64, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // typecmb
            // 
            this.typecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typecmb.FormattingEnabled = true;
            this.typecmb.Location = new System.Drawing.Point(71, 36);
            this.typecmb.Name = "typecmb";
            this.typecmb.Size = new System.Drawing.Size(130, 21);
            this.typecmb.TabIndex = 19;
            this.typecmb.SelectedIndexChanged += new System.EventHandler(this.typecmb_SelectedIndexChanged);
            this.typecmb.DropDown += new System.EventHandler(this.typecmb_DropDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.viewbtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(0, 201);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 37);
            this.panel1.TabIndex = 21;
            // 
            // viewbtn
            // 
            this.viewbtn.Location = new System.Drawing.Point(373, 6);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(64, 23);
            this.viewbtn.TabIndex = 1;
            this.viewbtn.Text = "View";
            this.viewbtn.UseVisualStyleBackColor = true;
            this.viewbtn.Click += new System.EventHandler(this.viewbtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(309, 6);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(64, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(245, 6);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(64, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtCode);
            this.panel3.Controls.Add(this.btnType);
            this.panel3.Controls.Add(this.rateBasedRadioButton);
            this.panel3.Controls.Add(this.fixedAmountRadioButton);
            this.panel3.Controls.Add(this.fixedAmountTextBox);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.inactivechkBox);
            this.panel3.Controls.Add(this.Level);
            this.panel3.Controls.Add(this.typecmb);
            this.panel3.Controls.Add(this.descriptiontxt);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(-1, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(510, 171);
            this.panel3.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Code:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(71, 61);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(94, 20);
            this.txtCode.TabIndex = 31;
            // 
            // btnType
            // 
            this.btnType.Location = new System.Drawing.Point(209, 35);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(26, 23);
            this.btnType.TabIndex = 30;
            this.btnType.Text = "...";
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // rateBasedRadioButton
            // 
            this.rateBasedRadioButton.AutoSize = true;
            this.rateBasedRadioButton.Location = new System.Drawing.Point(269, 63);
            this.rateBasedRadioButton.Name = "rateBasedRadioButton";
            this.rateBasedRadioButton.Size = new System.Drawing.Size(81, 17);
            this.rateBasedRadioButton.TabIndex = 29;
            this.rateBasedRadioButton.Text = "Rate Based";
            this.rateBasedRadioButton.UseVisualStyleBackColor = true;
            this.rateBasedRadioButton.CheckedChanged += new System.EventHandler(this.rateBasedRadioButton_CheckedChanged);
            // 
            // fixedAmountRadioButton
            // 
            this.fixedAmountRadioButton.AutoSize = true;
            this.fixedAmountRadioButton.Checked = true;
            this.fixedAmountRadioButton.Location = new System.Drawing.Point(269, 38);
            this.fixedAmountRadioButton.Name = "fixedAmountRadioButton";
            this.fixedAmountRadioButton.Size = new System.Drawing.Size(89, 17);
            this.fixedAmountRadioButton.TabIndex = 28;
            this.fixedAmountRadioButton.TabStop = true;
            this.fixedAmountRadioButton.Text = "Fixed Amount";
            this.fixedAmountRadioButton.UseVisualStyleBackColor = true;
            this.fixedAmountRadioButton.CheckedChanged += new System.EventHandler(this.fixedAmountRadioButton_CheckedChanged);
            // 
            // fixedAmountTextBox
            // 
            this.fixedAmountTextBox.Location = new System.Drawing.Point(364, 37);
            this.fixedAmountTextBox.Name = "fixedAmountTextBox";
            this.fixedAmountTextBox.Size = new System.Drawing.Size(75, 20);
            this.fixedAmountTextBox.TabIndex = 27;
            this.fixedAmountTextBox.TextChanged += new System.EventHandler(this.fixedAmountTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rateNud);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.calculatedOncmb);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(269, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 65);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // rateNud
            // 
            this.rateNud.DecimalPlaces = 2;
            this.rateNud.Location = new System.Drawing.Point(92, 11);
            this.rateNud.Name = "rateNud";
            this.rateNud.Size = new System.Drawing.Size(66, 20);
            this.rateNud.TabIndex = 26;
            this.rateNud.ValueChanged += new System.EventHandler(this.rateNud_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Rate(%)";
            // 
            // calculatedOncmb
            // 
            this.calculatedOncmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calculatedOncmb.FormattingEnabled = true;
            this.calculatedOncmb.Location = new System.Drawing.Point(92, 38);
            this.calculatedOncmb.Name = "calculatedOncmb";
            this.calculatedOncmb.Size = new System.Drawing.Size(130, 21);
            this.calculatedOncmb.TabIndex = 19;
            this.calculatedOncmb.SelectedIndexChanged += new System.EventHandler(this.calculatedOncmb_SelectedIndexChanged);
            this.calculatedOncmb.DropDown += new System.EventHandler(this.calculatedOncmb_DropDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Calculated On:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Active:";
            // 
            // inactivechkBox
            // 
            this.inactivechkBox.AutoSize = true;
            this.inactivechkBox.Location = new System.Drawing.Point(71, 111);
            this.inactivechkBox.Name = "inactivechkBox";
            this.inactivechkBox.Size = new System.Drawing.Size(15, 14);
            this.inactivechkBox.TabIndex = 24;
            this.inactivechkBox.UseVisualStyleBackColor = true;
            // 
            // descriptiontxt
            // 
            this.descriptiontxt.Location = new System.Drawing.Point(71, 85);
            this.descriptiontxt.Name = "descriptiontxt";
            this.descriptiontxt.Size = new System.Drawing.Size(164, 20);
            this.descriptiontxt.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Type:";
            // 
            // deductionTypeErrorProvider
            // 
            this.deductionTypeErrorProvider.ContainerControl = this;
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
            // Deduction_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(507, 238);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Deduction_Setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Deduction";
            this.Load += new System.EventHandler(this.Deduction_Setup_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deductionTypeErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deductionCategoryErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calculatedOnErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedAmountErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Level;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.ComboBox typecmb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button viewbtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox calculatedOncmb;
        private System.Windows.Forms.TextBox descriptiontxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider deductionTypeErrorProvider;
        private System.Windows.Forms.ErrorProvider deductionCategoryErrorProvider;
        private System.Windows.Forms.ErrorProvider calculatedOnErrorProvider;
        private System.Windows.Forms.ErrorProvider rateErrorProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown rateNud;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox inactivechkBox;
        private System.Windows.Forms.RadioButton rateBasedRadioButton;
        private System.Windows.Forms.RadioButton fixedAmountRadioButton;
        private System.Windows.Forms.TextBox fixedAmountTextBox;
        private System.Windows.Forms.ErrorProvider fixedAmountErrorProvider;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCode;
    }
}