namespace eMAS.Forms.SystemSetup
{
    partial class RosterGroups
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shiftComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sundayCheckBox = new System.Windows.Forms.CheckBox();
            this.saturdayCheckBox = new System.Windows.Forms.CheckBox();
            this.fridayCheckBox = new System.Windows.Forms.CheckBox();
            this.thursdayCheckBox = new System.Windows.Forms.CheckBox();
            this.wednesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.tuesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.mondayCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(70, 59);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(159, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Shift";
            // 
            // shiftComboBox
            // 
            this.shiftComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shiftComboBox.FormattingEnabled = true;
            this.shiftComboBox.Location = new System.Drawing.Point(70, 85);
            this.shiftComboBox.Name = "shiftComboBox";
            this.shiftComboBox.Size = new System.Drawing.Size(159, 21);
            this.shiftComboBox.TabIndex = 4;
            this.shiftComboBox.SelectedIndexChanged += new System.EventHandler(this.shiftComboBox_SelectedIndexChanged);
            this.shiftComboBox.DropDown += new System.EventHandler(this.shiftComboBox_DropDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sundayCheckBox);
            this.groupBox1.Controls.Add(this.saturdayCheckBox);
            this.groupBox1.Controls.Add(this.fridayCheckBox);
            this.groupBox1.Controls.Add(this.thursdayCheckBox);
            this.groupBox1.Controls.Add(this.wednesdayCheckBox);
            this.groupBox1.Controls.Add(this.tuesdayCheckBox);
            this.groupBox1.Controls.Add(this.mondayCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 83);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Work Days";
            // 
            // sundayCheckBox
            // 
            this.sundayCheckBox.AutoSize = true;
            this.sundayCheckBox.Location = new System.Drawing.Point(149, 52);
            this.sundayCheckBox.Name = "sundayCheckBox";
            this.sundayCheckBox.Size = new System.Drawing.Size(62, 17);
            this.sundayCheckBox.TabIndex = 6;
            this.sundayCheckBox.Text = "Sunday";
            this.sundayCheckBox.UseVisualStyleBackColor = true;
            // 
            // saturdayCheckBox
            // 
            this.saturdayCheckBox.AutoSize = true;
            this.saturdayCheckBox.Location = new System.Drawing.Point(76, 52);
            this.saturdayCheckBox.Name = "saturdayCheckBox";
            this.saturdayCheckBox.Size = new System.Drawing.Size(68, 17);
            this.saturdayCheckBox.TabIndex = 5;
            this.saturdayCheckBox.Text = "Saturday";
            this.saturdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // fridayCheckBox
            // 
            this.fridayCheckBox.AutoSize = true;
            this.fridayCheckBox.Location = new System.Drawing.Point(6, 52);
            this.fridayCheckBox.Name = "fridayCheckBox";
            this.fridayCheckBox.Size = new System.Drawing.Size(54, 17);
            this.fridayCheckBox.TabIndex = 4;
            this.fridayCheckBox.Text = "Friday";
            this.fridayCheckBox.UseVisualStyleBackColor = true;
            // 
            // thursdayCheckBox
            // 
            this.thursdayCheckBox.AutoSize = true;
            this.thursdayCheckBox.Location = new System.Drawing.Point(238, 25);
            this.thursdayCheckBox.Name = "thursdayCheckBox";
            this.thursdayCheckBox.Size = new System.Drawing.Size(70, 17);
            this.thursdayCheckBox.TabIndex = 3;
            this.thursdayCheckBox.Text = "Thursday";
            this.thursdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // wednesdayCheckBox
            // 
            this.wednesdayCheckBox.AutoSize = true;
            this.wednesdayCheckBox.Location = new System.Drawing.Point(149, 25);
            this.wednesdayCheckBox.Name = "wednesdayCheckBox";
            this.wednesdayCheckBox.Size = new System.Drawing.Size(83, 17);
            this.wednesdayCheckBox.TabIndex = 2;
            this.wednesdayCheckBox.Text = "Wednesday";
            this.wednesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // tuesdayCheckBox
            // 
            this.tuesdayCheckBox.AutoSize = true;
            this.tuesdayCheckBox.Location = new System.Drawing.Point(76, 25);
            this.tuesdayCheckBox.Name = "tuesdayCheckBox";
            this.tuesdayCheckBox.Size = new System.Drawing.Size(67, 17);
            this.tuesdayCheckBox.TabIndex = 1;
            this.tuesdayCheckBox.Text = "Tuesday";
            this.tuesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // mondayCheckBox
            // 
            this.mondayCheckBox.AutoSize = true;
            this.mondayCheckBox.Location = new System.Drawing.Point(6, 25);
            this.mondayCheckBox.Name = "mondayCheckBox";
            this.mondayCheckBox.Size = new System.Drawing.Size(64, 17);
            this.mondayCheckBox.TabIndex = 0;
            this.mondayCheckBox.Text = "Monday";
            this.mondayCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(545, 33);
            this.panel2.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Roster Groups";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.viewButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.clearButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(-1, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 34);
            this.panel1.TabIndex = 32;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(214, 6);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(60, 23);
            this.viewButton.TabIndex = 5;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(82, 6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(60, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(148, 6);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(60, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(280, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RosterGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(352, 267);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shiftComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Name = "RosterGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RosterGroups";
            this.Load += new System.EventHandler(this.RosterGroups_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox shiftComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox fridayCheckBox;
        private System.Windows.Forms.CheckBox thursdayCheckBox;
        private System.Windows.Forms.CheckBox wednesdayCheckBox;
        private System.Windows.Forms.CheckBox tuesdayCheckBox;
        private System.Windows.Forms.CheckBox mondayCheckBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.CheckBox sundayCheckBox;
        private System.Windows.Forms.CheckBox saturdayCheckBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}