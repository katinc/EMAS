namespace eMAS.Forms.SystemSetup
{
    partial class UserRoles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.viewbtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.userCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.level4ComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.level3ComboBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.viewCheckBox = new System.Windows.Forms.CheckBox();
            this.editCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteCheckBox = new System.Windows.Forms.CheckBox();
            this.addCheckBox = new System.Windows.Forms.CheckBox();
            this.printCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.level2ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.level1ComboBox = new System.Windows.Forms.ComboBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridCanPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridCanAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridCanDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridCanEdit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridCanView = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccessLevel1ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccessLevel2ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccessLevel3ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccessLevel4ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccessLevel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccessLevel2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccessLevel3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAccessLevel4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 31);
            this.panel2.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Manage Permissions";
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(606, 9);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(64, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // viewbtn
            // 
            this.viewbtn.Location = new System.Drawing.Point(468, 9);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(64, 23);
            this.viewbtn.TabIndex = 1;
            this.viewbtn.Text = "View";
            this.viewbtn.UseVisualStyleBackColor = true;
            this.viewbtn.Click += new System.EventHandler(this.viewbtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(538, 9);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(64, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.viewbtn);
            this.panel1.Controls.Add(this.clearbtn);
            this.panel1.Location = new System.Drawing.Point(0, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 41);
            this.panel1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Category:";
            // 
            // userCategoryComboBox
            // 
            this.userCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userCategoryComboBox.FormattingEnabled = true;
            this.userCategoryComboBox.Location = new System.Drawing.Point(100, 38);
            this.userCategoryComboBox.Name = "userCategoryComboBox";
            this.userCategoryComboBox.Size = new System.Drawing.Size(189, 21);
            this.userCategoryComboBox.TabIndex = 32;
            this.userCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.userCategoryComboBox_SelectedIndexChanged);
            this.userCategoryComboBox.DropDown += new System.EventHandler(this.userCategoryComboBox_DropDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.level4ComboBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.level3ComboBox);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.viewCheckBox);
            this.groupBox2.Controls.Add(this.editCheckBox);
            this.groupBox2.Controls.Add(this.deleteCheckBox);
            this.groupBox2.Controls.Add(this.addCheckBox);
            this.groupBox2.Controls.Add(this.printCheckBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.level2ComboBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.level1ComboBox);
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.Location = new System.Drawing.Point(11, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(737, 502);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Access Levels";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Access Level 4:";
            // 
            // level4ComboBox
            // 
            this.level4ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.level4ComboBox.FormattingEnabled = true;
            this.level4ComboBox.Location = new System.Drawing.Point(380, 41);
            this.level4ComboBox.Name = "level4ComboBox";
            this.level4ComboBox.Size = new System.Drawing.Size(186, 21);
            this.level4ComboBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Access Level 3:";
            // 
            // level3ComboBox
            // 
            this.level3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.level3ComboBox.FormattingEnabled = true;
            this.level3ComboBox.Location = new System.Drawing.Point(92, 40);
            this.level3ComboBox.Name = "level3ComboBox";
            this.level3ComboBox.Size = new System.Drawing.Size(186, 21);
            this.level3ComboBox.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(322, 70);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // viewCheckBox
            // 
            this.viewCheckBox.AutoSize = true;
            this.viewCheckBox.Location = new System.Drawing.Point(245, 74);
            this.viewCheckBox.Name = "viewCheckBox";
            this.viewCheckBox.Size = new System.Drawing.Size(49, 17);
            this.viewCheckBox.TabIndex = 9;
            this.viewCheckBox.Text = "View";
            this.viewCheckBox.UseVisualStyleBackColor = true;
            // 
            // editCheckBox
            // 
            this.editCheckBox.AutoSize = true;
            this.editCheckBox.Location = new System.Drawing.Point(192, 74);
            this.editCheckBox.Name = "editCheckBox";
            this.editCheckBox.Size = new System.Drawing.Size(44, 17);
            this.editCheckBox.TabIndex = 8;
            this.editCheckBox.Text = "Edit";
            this.editCheckBox.UseVisualStyleBackColor = true;
            // 
            // deleteCheckBox
            // 
            this.deleteCheckBox.AutoSize = true;
            this.deleteCheckBox.Location = new System.Drawing.Point(127, 74);
            this.deleteCheckBox.Name = "deleteCheckBox";
            this.deleteCheckBox.Size = new System.Drawing.Size(57, 17);
            this.deleteCheckBox.TabIndex = 7;
            this.deleteCheckBox.Text = "Delete";
            this.deleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // addCheckBox
            // 
            this.addCheckBox.AutoSize = true;
            this.addCheckBox.Location = new System.Drawing.Point(72, 74);
            this.addCheckBox.Name = "addCheckBox";
            this.addCheckBox.Size = new System.Drawing.Size(45, 17);
            this.addCheckBox.TabIndex = 6;
            this.addCheckBox.Text = "Add";
            this.addCheckBox.UseVisualStyleBackColor = true;
            // 
            // printCheckBox
            // 
            this.printCheckBox.AutoSize = true;
            this.printCheckBox.Location = new System.Drawing.Point(19, 74);
            this.printCheckBox.Name = "printCheckBox";
            this.printCheckBox.Size = new System.Drawing.Size(47, 17);
            this.printCheckBox.TabIndex = 5;
            this.printCheckBox.Text = "Print";
            this.printCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Access Level 2:";
            // 
            // level2ComboBox
            // 
            this.level2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.level2ComboBox.FormattingEnabled = true;
            this.level2ComboBox.Location = new System.Drawing.Point(380, 19);
            this.level2ComboBox.Name = "level2ComboBox";
            this.level2ComboBox.Size = new System.Drawing.Size(186, 21);
            this.level2ComboBox.TabIndex = 3;
            this.level2ComboBox.SelectionChangeCommitted += new System.EventHandler(this.level2ComboBox_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Access Level 1:";
            // 
            // level1ComboBox
            // 
            this.level1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.level1ComboBox.FormattingEnabled = true;
            this.level1ComboBox.Location = new System.Drawing.Point(92, 18);
            this.level1ComboBox.Name = "level1ComboBox";
            this.level1ComboBox.Size = new System.Drawing.Size(186, 21);
            this.level1ComboBox.TabIndex = 1;
            this.level1ComboBox.SelectionChangeCommitted += new System.EventHandler(this.level1ComboBox_SelectionChangeCommitted);
            this.level1ComboBox.DropDown += new System.EventHandler(this.level1ComboBox_DropDown);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridAccessLevel1ID,
            this.gridAccessLevel2ID,
            this.gridAccessLevel3ID,
            this.gridAccessLevel4ID,
            this.gridAccessLevel1,
            this.gridAccessLevel2,
            this.gridAccessLevel3,
            this.gridAccessLevel4,
            this.gridCanPrint,
            this.gridCanAdd,
            this.gridCanDelete,
            this.gridCanEdit,
            this.gridCanView});
            this.grid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grid.Location = new System.Drawing.Point(3, 101);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(731, 398);
            this.grid.TabIndex = 0;
            // 
            // gridCanPrint
            // 
            this.gridCanPrint.HeaderText = "Print";
            this.gridCanPrint.Name = "gridCanPrint";
            this.gridCanPrint.ReadOnly = true;
            this.gridCanPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCanPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridCanPrint.Width = 40;
            // 
            // gridCanAdd
            // 
            this.gridCanAdd.HeaderText = "Add";
            this.gridCanAdd.Name = "gridCanAdd";
            this.gridCanAdd.ReadOnly = true;
            this.gridCanAdd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCanAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridCanAdd.Width = 40;
            // 
            // gridCanDelete
            // 
            this.gridCanDelete.HeaderText = "Delete";
            this.gridCanDelete.Name = "gridCanDelete";
            this.gridCanDelete.ReadOnly = true;
            this.gridCanDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCanDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridCanDelete.Width = 50;
            // 
            // gridCanEdit
            // 
            this.gridCanEdit.HeaderText = "Edit";
            this.gridCanEdit.Name = "gridCanEdit";
            this.gridCanEdit.ReadOnly = true;
            this.gridCanEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCanEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridCanEdit.Width = 40;
            // 
            // gridCanView
            // 
            this.gridCanView.HeaderText = "View";
            this.gridCanView.Name = "gridCanView";
            this.gridCanView.ReadOnly = true;
            this.gridCanView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCanView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridCanView.Width = 40;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Access Level 1 ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Access Level 2 ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Access Level 1";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Access Level 2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Access Level 1";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Access Level 2";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Access Level 3";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Access Level 4";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.ReadOnly = true;
            this.gridID.Visible = false;
            // 
            // gridAccessLevel1ID
            // 
            this.gridAccessLevel1ID.HeaderText = "AccessLevel1ID";
            this.gridAccessLevel1ID.Name = "gridAccessLevel1ID";
            this.gridAccessLevel1ID.ReadOnly = true;
            this.gridAccessLevel1ID.Visible = false;
            // 
            // gridAccessLevel2ID
            // 
            this.gridAccessLevel2ID.HeaderText = "AccessLevel2ID";
            this.gridAccessLevel2ID.Name = "gridAccessLevel2ID";
            this.gridAccessLevel2ID.ReadOnly = true;
            this.gridAccessLevel2ID.Visible = false;
            // 
            // gridAccessLevel3ID
            // 
            this.gridAccessLevel3ID.HeaderText = "Access Level3ID";
            this.gridAccessLevel3ID.Name = "gridAccessLevel3ID";
            this.gridAccessLevel3ID.ReadOnly = true;
            this.gridAccessLevel3ID.Visible = false;
            // 
            // gridAccessLevel4ID
            // 
            this.gridAccessLevel4ID.HeaderText = "Access Level4ID";
            this.gridAccessLevel4ID.Name = "gridAccessLevel4ID";
            this.gridAccessLevel4ID.ReadOnly = true;
            this.gridAccessLevel4ID.Visible = false;
            // 
            // gridAccessLevel1
            // 
            this.gridAccessLevel1.HeaderText = "Access Level 1";
            this.gridAccessLevel1.Name = "gridAccessLevel1";
            this.gridAccessLevel1.ReadOnly = true;
            this.gridAccessLevel1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAccessLevel1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridAccessLevel1.Width = 120;
            // 
            // gridAccessLevel2
            // 
            this.gridAccessLevel2.HeaderText = "Access Level 2";
            this.gridAccessLevel2.Name = "gridAccessLevel2";
            this.gridAccessLevel2.ReadOnly = true;
            this.gridAccessLevel2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAccessLevel2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridAccessLevel2.Width = 120;
            // 
            // gridAccessLevel3
            // 
            this.gridAccessLevel3.HeaderText = "Access Level 3";
            this.gridAccessLevel3.Name = "gridAccessLevel3";
            this.gridAccessLevel3.ReadOnly = true;
            this.gridAccessLevel3.Width = 120;
            // 
            // gridAccessLevel4
            // 
            this.gridAccessLevel4.HeaderText = "Access Level 4";
            this.gridAccessLevel4.Name = "gridAccessLevel4";
            this.gridAccessLevel4.ReadOnly = true;
            this.gridAccessLevel4.Width = 120;
            // 
            // UserRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(760, 603);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.userCategoryComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UserRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Permissions";
            this.Load += new System.EventHandler(this.UserCategories_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button viewbtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox userCategoryComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox level1ComboBox;
        private System.Windows.Forms.CheckBox viewCheckBox;
        private System.Windows.Forms.CheckBox editCheckBox;
        private System.Windows.Forms.CheckBox deleteCheckBox;
        private System.Windows.Forms.CheckBox addCheckBox;
        private System.Windows.Forms.CheckBox printCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox level2ComboBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox level4ComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox level3ComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccessLevel1ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccessLevel2ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccessLevel3ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccessLevel4ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccessLevel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccessLevel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccessLevel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAccessLevel4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridCanPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridCanAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridCanDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridCanEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gridCanView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}