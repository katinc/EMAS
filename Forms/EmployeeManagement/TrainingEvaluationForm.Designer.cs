
namespace eMAS.Forms.EmployeeManagement
{
    partial class TrainingEvaluationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFurtherComments = new System.Windows.Forms.TextBox();
            this.txtSkillImpediments = new System.Windows.Forms.TextBox();
            this.txtProgramLimitations = new System.Windows.Forms.TextBox();
            this.tab = new System.Windows.Forms.TabControl();
            this.topicAssessment = new System.Windows.Forms.TabPage();
            this.gridTopicAssessment = new System.Windows.Forms.DataGridView();
            this.grid1Topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid1Assessment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.facilitatorRating = new System.Windows.Forms.TabPage();
            this.gridFacilitatorRating = new System.Windows.Forms.DataGridView();
            this.grid2ResourcePerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid2Assessment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.trainingRelevance = new System.Windows.Forms.TabPage();
            this.gridTrainingRelevance = new System.Windows.Forms.DataGridView();
            this.grid3Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid3Assessment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.trainingAdministrationImpression = new System.Windows.Forms.TabPage();
            this.gridAdministrationImpression = new System.Windows.Forms.DataGridView();
            this.grid4Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid4Assessment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.cmbTraining = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnViewEntries = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.tab.SuspendLayout();
            this.topicAssessment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTopicAssessment)).BeginInit();
            this.facilitatorRating.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacilitatorRating)).BeginInit();
            this.trainingRelevance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrainingRelevance)).BeginInit();
            this.trainingAdministrationImpression.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdministrationImpression)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Participant\'s In-Service Training Evaluation Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "In your opinion, what were some of the limitations of the programme you identifie" +
    "d?\r\n";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.txtFurtherComments);
            this.groupBox2.Controls.Add(this.txtSkillImpediments);
            this.groupBox2.Controls.Add(this.txtProgramLimitations);
            this.groupBox2.Controls.Add(this.tab);
            this.groupBox2.Controls.Add(this.date);
            this.groupBox2.Controls.Add(this.cmbTraining);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 600);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtFurtherComments
            // 
            this.txtFurtherComments.Location = new System.Drawing.Point(30, 530);
            this.txtFurtherComments.Margin = new System.Windows.Forms.Padding(2);
            this.txtFurtherComments.Multiline = true;
            this.txtFurtherComments.Name = "txtFurtherComments";
            this.txtFurtherComments.Size = new System.Drawing.Size(590, 54);
            this.txtFurtherComments.TabIndex = 33;
            // 
            // txtSkillImpediments
            // 
            this.txtSkillImpediments.Location = new System.Drawing.Point(29, 447);
            this.txtSkillImpediments.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkillImpediments.Multiline = true;
            this.txtSkillImpediments.Name = "txtSkillImpediments";
            this.txtSkillImpediments.Size = new System.Drawing.Size(590, 54);
            this.txtSkillImpediments.TabIndex = 33;
            // 
            // txtProgramLimitations
            // 
            this.txtProgramLimitations.Location = new System.Drawing.Point(30, 362);
            this.txtProgramLimitations.Margin = new System.Windows.Forms.Padding(2);
            this.txtProgramLimitations.Multiline = true;
            this.txtProgramLimitations.Name = "txtProgramLimitations";
            this.txtProgramLimitations.Size = new System.Drawing.Size(590, 54);
            this.txtProgramLimitations.TabIndex = 33;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.topicAssessment);
            this.tab.Controls.Add(this.facilitatorRating);
            this.tab.Controls.Add(this.trainingRelevance);
            this.tab.Controls.Add(this.trainingAdministrationImpression);
            this.tab.Location = new System.Drawing.Point(26, 46);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(605, 288);
            this.tab.TabIndex = 32;
            // 
            // topicAssessment
            // 
            this.topicAssessment.Controls.Add(this.gridTopicAssessment);
            this.topicAssessment.Location = new System.Drawing.Point(4, 22);
            this.topicAssessment.Name = "topicAssessment";
            this.topicAssessment.Padding = new System.Windows.Forms.Padding(3);
            this.topicAssessment.Size = new System.Drawing.Size(597, 262);
            this.topicAssessment.TabIndex = 17;
            this.topicAssessment.Text = "Topic Assessment";
            this.topicAssessment.UseVisualStyleBackColor = true;
            // 
            // gridTopicAssessment
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            this.gridTopicAssessment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gridTopicAssessment.BackgroundColor = System.Drawing.Color.SlateGray;
            this.gridTopicAssessment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTopicAssessment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid1Topic,
            this.grid1Assessment});
            this.gridTopicAssessment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTopicAssessment.GridColor = System.Drawing.SystemColors.Control;
            this.gridTopicAssessment.Location = new System.Drawing.Point(3, 3);
            this.gridTopicAssessment.Name = "gridTopicAssessment";
            this.gridTopicAssessment.RowHeadersWidth = 23;
            this.gridTopicAssessment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridTopicAssessment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTopicAssessment.Size = new System.Drawing.Size(591, 256);
            this.gridTopicAssessment.TabIndex = 5;
            this.gridTopicAssessment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTopicAssessment_CellClick);
            // 
            // grid1Topic
            // 
            this.grid1Topic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid1Topic.HeaderText = "Topic";
            this.grid1Topic.Name = "grid1Topic";
            this.grid1Topic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // grid1Assessment
            // 
            this.grid1Assessment.HeaderText = "Assessment";
            this.grid1Assessment.Name = "grid1Assessment";
            this.grid1Assessment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grid1Assessment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grid1Assessment.Width = 250;
            // 
            // facilitatorRating
            // 
            this.facilitatorRating.Controls.Add(this.gridFacilitatorRating);
            this.facilitatorRating.Location = new System.Drawing.Point(4, 22);
            this.facilitatorRating.Name = "facilitatorRating";
            this.facilitatorRating.Size = new System.Drawing.Size(597, 262);
            this.facilitatorRating.TabIndex = 8;
            this.facilitatorRating.Text = "Facilitator Rating";
            this.facilitatorRating.UseVisualStyleBackColor = true;
            // 
            // gridFacilitatorRating
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGray;
            this.gridFacilitatorRating.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gridFacilitatorRating.BackgroundColor = System.Drawing.Color.SlateGray;
            this.gridFacilitatorRating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFacilitatorRating.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid2ResourcePerson,
            this.grid2Assessment});
            this.gridFacilitatorRating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFacilitatorRating.GridColor = System.Drawing.SystemColors.Control;
            this.gridFacilitatorRating.Location = new System.Drawing.Point(0, 0);
            this.gridFacilitatorRating.Name = "gridFacilitatorRating";
            this.gridFacilitatorRating.RowHeadersWidth = 23;
            this.gridFacilitatorRating.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridFacilitatorRating.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFacilitatorRating.Size = new System.Drawing.Size(597, 262);
            this.gridFacilitatorRating.TabIndex = 6;
            this.gridFacilitatorRating.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFacilitatorRating_CellClick);
            // 
            // grid2ResourcePerson
            // 
            this.grid2ResourcePerson.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid2ResourcePerson.HeaderText = "Resource Person";
            this.grid2ResourcePerson.Name = "grid2ResourcePerson";
            this.grid2ResourcePerson.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // grid2Assessment
            // 
            this.grid2Assessment.HeaderText = "Assessment";
            this.grid2Assessment.Name = "grid2Assessment";
            this.grid2Assessment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grid2Assessment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grid2Assessment.Width = 250;
            // 
            // trainingRelevance
            // 
            this.trainingRelevance.BackColor = System.Drawing.Color.Lavender;
            this.trainingRelevance.Controls.Add(this.gridTrainingRelevance);
            this.trainingRelevance.Location = new System.Drawing.Point(4, 22);
            this.trainingRelevance.Name = "trainingRelevance";
            this.trainingRelevance.Padding = new System.Windows.Forms.Padding(3);
            this.trainingRelevance.Size = new System.Drawing.Size(597, 262);
            this.trainingRelevance.TabIndex = 14;
            this.trainingRelevance.Text = "Relevance of Traning";
            this.trainingRelevance.UseVisualStyleBackColor = true;
            // 
            // gridTrainingRelevance
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray;
            this.gridTrainingRelevance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridTrainingRelevance.BackgroundColor = System.Drawing.Color.SlateGray;
            this.gridTrainingRelevance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTrainingRelevance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid3Item,
            this.grid3Assessment});
            this.gridTrainingRelevance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrainingRelevance.GridColor = System.Drawing.SystemColors.Control;
            this.gridTrainingRelevance.Location = new System.Drawing.Point(3, 3);
            this.gridTrainingRelevance.Name = "gridTrainingRelevance";
            this.gridTrainingRelevance.RowHeadersWidth = 23;
            this.gridTrainingRelevance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridTrainingRelevance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTrainingRelevance.Size = new System.Drawing.Size(591, 256);
            this.gridTrainingRelevance.TabIndex = 6;
            this.gridTrainingRelevance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTrainingRelevance_CellClick);
            // 
            // grid3Item
            // 
            this.grid3Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid3Item.HeaderText = "Item";
            this.grid3Item.Name = "grid3Item";
            this.grid3Item.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // grid3Assessment
            // 
            this.grid3Assessment.HeaderText = "Assessment";
            this.grid3Assessment.Name = "grid3Assessment";
            this.grid3Assessment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grid3Assessment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grid3Assessment.Width = 250;
            // 
            // trainingAdministrationImpression
            // 
            this.trainingAdministrationImpression.BackColor = System.Drawing.Color.Lavender;
            this.trainingAdministrationImpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trainingAdministrationImpression.Controls.Add(this.gridAdministrationImpression);
            this.trainingAdministrationImpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainingAdministrationImpression.Location = new System.Drawing.Point(4, 22);
            this.trainingAdministrationImpression.Name = "trainingAdministrationImpression";
            this.trainingAdministrationImpression.Padding = new System.Windows.Forms.Padding(3);
            this.trainingAdministrationImpression.Size = new System.Drawing.Size(597, 262);
            this.trainingAdministrationImpression.TabIndex = 16;
            this.trainingAdministrationImpression.Text = "Training Administration Impression";
            this.trainingAdministrationImpression.UseVisualStyleBackColor = true;
            // 
            // gridAdministrationImpression
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightGray;
            this.gridAdministrationImpression.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.gridAdministrationImpression.BackgroundColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAdministrationImpression.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gridAdministrationImpression.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAdministrationImpression.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid4Item,
            this.grid4Assessment});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAdministrationImpression.DefaultCellStyle = dataGridViewCellStyle13;
            this.gridAdministrationImpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAdministrationImpression.GridColor = System.Drawing.SystemColors.Control;
            this.gridAdministrationImpression.Location = new System.Drawing.Point(3, 3);
            this.gridAdministrationImpression.Name = "gridAdministrationImpression";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAdministrationImpression.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gridAdministrationImpression.RowHeadersWidth = 23;
            this.gridAdministrationImpression.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridAdministrationImpression.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAdministrationImpression.Size = new System.Drawing.Size(589, 254);
            this.gridAdministrationImpression.TabIndex = 6;
            this.gridAdministrationImpression.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAdministrationImpression_CellClick);
            // 
            // grid4Item
            // 
            this.grid4Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grid4Item.HeaderText = "Item";
            this.grid4Item.Name = "grid4Item";
            this.grid4Item.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // grid4Assessment
            // 
            this.grid4Assessment.HeaderText = "Assessment";
            this.grid4Assessment.Name = "grid4Assessment";
            this.grid4Assessment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grid4Assessment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grid4Assessment.Width = 250;
            // 
            // date
            // 
            this.date.CustomFormat = "dd/MM/yyyy";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(486, 19);
            this.date.Name = "date";
            this.date.ShowCheckBox = true;
            this.date.Size = new System.Drawing.Size(141, 20);
            this.date.TabIndex = 31;
            this.date.Value = new System.DateTime(2021, 10, 31, 0, 0, 0, 0);
            // 
            // cmbTraining
            // 
            this.cmbTraining.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmbTraining.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTraining.FormattingEnabled = true;
            this.cmbTraining.Items.AddRange(new object[] {
            "Sick Leave",
            "Study Leave",
            "Maternity Leave"});
            this.cmbTraining.Location = new System.Drawing.Point(128, 19);
            this.cmbTraining.Name = "cmbTraining";
            this.cmbTraining.Size = new System.Drawing.Size(303, 21);
            this.cmbTraining.TabIndex = 30;
            this.cmbTraining.DropDown += new System.EventHandler(this.cmbTraining_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(450, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Course (broad) Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 515);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Any further comments on the training:\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(372, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "State any anticipated impediment to transferring the acquired skills to your job:" +
    "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnViewEntries);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Location = new System.Drawing.Point(12, 631);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(656, 35);
            this.panel2.TabIndex = 46;
            // 
            // btnViewEntries
            // 
            this.btnViewEntries.Location = new System.Drawing.Point(3, 5);
            this.btnViewEntries.Name = "btnViewEntries";
            this.btnViewEntries.Size = new System.Drawing.Size(73, 23);
            this.btnViewEntries.TabIndex = 4;
            this.btnViewEntries.Text = "View";
            this.btnViewEntries.UseVisualStyleBackColor = true;
            this.btnViewEntries.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(406, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(569, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(492, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(71, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Topic";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Resource Person (Name)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Item";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Item";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // TrainingEvaluationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(682, 672);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Name = "TrainingEvaluationForm";
            this.Text = "TrainingEvaluationForm";
            this.Load += new System.EventHandler(this.TrainingEvaluationForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tab.ResumeLayout(false);
            this.topicAssessment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTopicAssessment)).EndInit();
            this.facilitatorRating.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFacilitatorRating)).EndInit();
            this.trainingRelevance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTrainingRelevance)).EndInit();
            this.trainingAdministrationImpression.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdministrationImpression)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbTraining;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage topicAssessment;
        private System.Windows.Forms.DataGridView gridTopicAssessment;
        private System.Windows.Forms.TabPage facilitatorRating;
        private System.Windows.Forms.TabPage trainingRelevance;
        private System.Windows.Forms.TabPage trainingAdministrationImpression;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid1Topic;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid1Assessment;
        private System.Windows.Forms.TextBox txtProgramLimitations;
        private System.Windows.Forms.TextBox txtFurtherComments;
        private System.Windows.Forms.TextBox txtSkillImpediments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnViewEntries;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView gridFacilitatorRating;
        private System.Windows.Forms.DataGridView gridTrainingRelevance;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid3Item;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid3Assessment;
        private System.Windows.Forms.DataGridView gridAdministrationImpression;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid4Item;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid4Assessment;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid2ResourcePerson;
        private System.Windows.Forms.DataGridViewComboBoxColumn grid2Assessment;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}