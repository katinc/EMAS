namespace eMAS.All_UIs.System_SetupFORMS
{
    partial class Employee_Grades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.gradeCategorycmb = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gradeLevelsgrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGUSSCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridStartStep = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridEndStep = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.viewbtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.gradeCategoryErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gridErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradeLevelsgrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradeCategoryErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grade Category:";
            // 
            // gradeCategorycmb
            // 
            this.gradeCategorycmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeCategorycmb.FormattingEnabled = true;
            this.gradeCategorycmb.Location = new System.Drawing.Point(99, 66);
            this.gradeCategorycmb.Name = "gradeCategorycmb";
            this.gradeCategorycmb.Size = new System.Drawing.Size(161, 21);
            this.gradeCategorycmb.TabIndex = 1;
            this.gradeCategorycmb.DropDown += new System.EventHandler(this.gradeCategorycmb_DropDown);
            this.gradeCategorycmb.SelectedIndexChanged += new System.EventHandler(this.gradeCategorycmb_SelectedIndexChanged);
            this.gradeCategorycmb.SelectionChangeCommitted += new System.EventHandler(this.gradeCategorycmb_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gradeLevelsgrid);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(15, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 195);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // gradeLevelsgrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.gradeLevelsgrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gradeLevelsgrid.BackgroundColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gradeLevelsgrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gradeLevelsgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gradeLevelsgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.gridGUSSCode,
            this.gridGrade,
            this.gridLevel,
            this.gridStartStep,
            this.gridEndStep,
            this.gridActive});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gradeLevelsgrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.gradeLevelsgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeLevelsgrid.GridColor = System.Drawing.Color.DarkGray;
            this.gradeLevelsgrid.Location = new System.Drawing.Point(3, 16);
            this.gradeLevelsgrid.Name = "gradeLevelsgrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gradeLevelsgrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gradeLevelsgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gradeLevelsgrid.Size = new System.Drawing.Size(683, 176);
            this.gradeLevelsgrid.TabIndex = 0;
            this.gradeLevelsgrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gradeLevelsgrid_CellClick);
            this.gradeLevelsgrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gradeLevelsgrid_CellContentClick);
            this.gradeLevelsgrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gradeLevelsgrid_DataError);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // gridGUSSCode
            // 
            this.gridGUSSCode.FillWeight = 121.8274F;
            this.gridGUSSCode.HeaderText = "Code";
            this.gridGUSSCode.Name = "gridGUSSCode";
            this.gridGUSSCode.Width = 80;
            // 
            // gridGrade
            // 
            this.gridGrade.FillWeight = 121.8274F;
            this.gridGrade.HeaderText = "Grade";
            this.gridGrade.Name = "gridGrade";
            this.gridGrade.Width = 200;
            // 
            // gridLevel
            // 
            this.gridLevel.FillWeight = 121.8274F;
            this.gridLevel.HeaderText = "Level";
            this.gridLevel.Name = "gridLevel";
            this.gridLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridStartStep
            // 
            this.gridStartStep.FillWeight = 12.69036F;
            this.gridStartStep.HeaderText = "Start Step";
            this.gridStartStep.Name = "gridStartStep";
            this.gridStartStep.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridStartStep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gridEndStep
            // 
            this.gridEndStep.HeaderText = "End Step";
            this.gridEndStep.Name = "gridEndStep";
            // 
            // gridActive
            // 
            this.gridActive.FillWeight = 121.8274F;
            this.gridActive.HeaderText = "Active";
            this.gridActive.Name = "gridActive";
            this.gridActive.Width = 70;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.viewbtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(0, 327);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 38);
            this.panel1.TabIndex = 12;
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(647, 10);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(64, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // viewbtn
            // 
            this.viewbtn.Location = new System.Drawing.Point(577, 10);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(64, 23);
            this.viewbtn.TabIndex = 1;
            this.viewbtn.Text = "View";
            this.viewbtn.UseVisualStyleBackColor = true;
            this.viewbtn.Visible = false;
            this.viewbtn.Click += new System.EventHandler(this.viewbtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(507, 10);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(64, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(437, 10);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(64, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(716, 40);
            this.panel2.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(19, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee Grades";
            // 
            // gradeCategoryErrorProvider
            // 
            this.gradeCategoryErrorProvider.ContainerControl = this;
            // 
            // gridErrorProvider
            // 
            this.gridErrorProvider.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 121.8274F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 121.8274F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 121.8274F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Level";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 12.69036F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Basic Salary";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "HourRate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // Employee_Grades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(716, 375);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gradeCategorycmb);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Employee_Grades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee_Grades";
            this.Load += new System.EventHandler(this.Employee_Grades_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradeLevelsgrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradeCategoryErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox gradeCategorycmb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gradeLevelsgrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button viewbtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider gradeCategoryErrorProvider;
        private System.Windows.Forms.ErrorProvider gridErrorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGUSSCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridGrade;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridLevel;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridStartStep;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridEndStep;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridActive;
    }
}