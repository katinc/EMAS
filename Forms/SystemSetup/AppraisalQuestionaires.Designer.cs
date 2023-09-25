namespace eMAS.Forms.SystemSetup
{
    partial class AppraisalQuestionaires
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
            try
            {
                dal.CloseConnection();
            }
            catch (System.Exception ex)
            {
                string err = ex.Message;
            }
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
            this.btnClear = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnswerA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnswerB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnswerC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnswerD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAnswerE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subjectiveGrid = new System.Windows.Forms.DataGridView();
            this.subGridNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subGridQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gradeCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gradeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.appraisalTypesComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectiveGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(581, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridNo,
            this.gridQuestion,
            this.gridAnswerA,
            this.gridAnswerB,
            this.gridAnswerC,
            this.gridAnswerD,
            this.gridAnswerE});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 16);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 21;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.Size = new System.Drawing.Size(752, 192);
            this.grid.TabIndex = 45;
            this.grid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            // 
            // gridNo
            // 
            this.gridNo.HeaderText = "No";
            this.gridNo.Name = "gridNo";
            this.gridNo.Width = 35;
            // 
            // gridQuestion
            // 
            this.gridQuestion.HeaderText = "Question";
            this.gridQuestion.Name = "gridQuestion";
            this.gridQuestion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridQuestion.Width = 287;
            // 
            // gridAnswerA
            // 
            this.gridAnswerA.HeaderText = "Answer A";
            this.gridAnswerA.Name = "gridAnswerA";
            this.gridAnswerA.Width = 80;
            // 
            // gridAnswerB
            // 
            this.gridAnswerB.HeaderText = "Answer B";
            this.gridAnswerB.Name = "gridAnswerB";
            this.gridAnswerB.Width = 80;
            // 
            // gridAnswerC
            // 
            this.gridAnswerC.HeaderText = "Answer C";
            this.gridAnswerC.Name = "gridAnswerC";
            this.gridAnswerC.Width = 80;
            // 
            // gridAnswerD
            // 
            this.gridAnswerD.HeaderText = "Answer D";
            this.gridAnswerD.Name = "gridAnswerD";
            this.gridAnswerD.Width = 80;
            // 
            // gridAnswerE
            // 
            this.gridAnswerE.HeaderText = "Answer E";
            this.gridAnswerE.Name = "gridAnswerE";
            this.gridAnswerE.Width = 80;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(-1, 541);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 39);
            this.panel1.TabIndex = 52;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(641, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(54, 23);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(701, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(521, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grid);
            this.groupBox3.Location = new System.Drawing.Point(14, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(758, 211);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Objective Questions";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 35);
            this.panel2.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Appraisal Questionnaire";
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.subjectiveGrid);
            this.groupBox1.Location = new System.Drawing.Point(14, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 200);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subjective Questions";
            // 
            // subjectiveGrid
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subjectiveGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.subjectiveGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectiveGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subGridNo,
            this.subGridQuestion});
            this.subjectiveGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectiveGrid.Location = new System.Drawing.Point(3, 16);
            this.subjectiveGrid.Name = "subjectiveGrid";
            this.subjectiveGrid.RowHeadersWidth = 21;
            this.subjectiveGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.subjectiveGrid.Size = new System.Drawing.Size(752, 181);
            this.subjectiveGrid.TabIndex = 45;
            this.subjectiveGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.subjectiveGrid_RowsAdded);
            // 
            // subGridNo
            // 
            this.subGridNo.FillWeight = 35.53299F;
            this.subGridNo.HeaderText = "No";
            this.subGridNo.Name = "subGridNo";
            this.subGridNo.Width = 35;
            // 
            // subGridQuestion
            // 
            this.subGridQuestion.FillWeight = 164.467F;
            this.subGridQuestion.HeaderText = "Question";
            this.subGridQuestion.Name = "subGridQuestion";
            this.subGridQuestion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.subGridQuestion.Width = 700;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.gradeCategoryComboBox);
            this.groupBox2.Controls.Add(this.endDatePicker);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.startDatePicker);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.gradeComboBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.appraisalTypesComboBox);
            this.groupBox2.Location = new System.Drawing.Point(14, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(758, 82);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Appraisal Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Grade:";
            // 
            // gradeCategoryComboBox
            // 
            this.gradeCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeCategoryComboBox.FormattingEnabled = true;
            this.gradeCategoryComboBox.Location = new System.Drawing.Point(326, 23);
            this.gradeCategoryComboBox.Name = "gradeCategoryComboBox";
            this.gradeCategoryComboBox.Size = new System.Drawing.Size(177, 21);
            this.gradeCategoryComboBox.TabIndex = 72;
            this.gradeCategoryComboBox.DropDown += new System.EventHandler(this.gradeCategoryComboBox_DropDown);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDatePicker.Location = new System.Drawing.Point(336, 50);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(98, 20);
            this.endDatePicker.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "End Date";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(65, 50);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(98, 20);
            this.startDatePicker.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Grade Category:";
            // 
            // gradeComboBox
            // 
            this.gradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeComboBox.FormattingEnabled = true;
            this.gradeComboBox.Location = new System.Drawing.Point(556, 23);
            this.gradeComboBox.Name = "gradeComboBox";
            this.gradeComboBox.Size = new System.Drawing.Size(177, 21);
            this.gradeComboBox.TabIndex = 66;
            this.gradeComboBox.DropDown += new System.EventHandler(this.gradeComboBox_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Appraisal Type";
            // 
            // appraisalTypesComboBox
            // 
            this.appraisalTypesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appraisalTypesComboBox.FormattingEnabled = true;
            this.appraisalTypesComboBox.Location = new System.Drawing.Point(91, 23);
            this.appraisalTypesComboBox.Name = "appraisalTypesComboBox";
            this.appraisalTypesComboBox.Size = new System.Drawing.Size(141, 21);
            this.appraisalTypesComboBox.TabIndex = 64;
            this.appraisalTypesComboBox.DropDown += new System.EventHandler(this.appraisalTypesComboBox_DropDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Question";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.Width = 420;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Answer A";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Answer B";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Answer C";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Answer D";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Answer E";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Answer E";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 35.53299F;
            this.dataGridViewTextBoxColumn8.HeaderText = "No";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 35;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.FillWeight = 164.467F;
            this.dataGridViewTextBoxColumn9.HeaderText = "subGridQuestion";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.Width = 820;
            // 
            // AppraisalQuestionaires
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 583);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "AppraisalQuestionaires";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appraisal Questionaires";
            this.Load += new System.EventHandler(this.AppraisalQuestionaires_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subjectiveGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView subjectiveGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox gradeCategoryComboBox;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox gradeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox appraisalTypesComboBox;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnswerA;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnswerB;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnswerC;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnswerD;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAnswerE;
        private System.Windows.Forms.DataGridViewTextBoxColumn subGridNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn subGridQuestion;
    }
}